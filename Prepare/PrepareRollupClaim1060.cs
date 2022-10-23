using System;
using System.IO;
using Novus.PayerBase;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class PrepareRollupClaim1060 : PrepareClaimHeaderBase
    {
        #region DECLARATIONS

        ///Claim Header ( adHocClaimHeaderFile )
        private readonly string adHocClaimHeaderFileName;
        private readonly FdOptumCareHcpClaim fdClaimHeader;

        ///Claim Line ( adHocClaimHeaderFileA )
        private readonly FdOptumCareHcpClaimLine claimLineRawFile;
        private readonly string claimLineFile;

        ///Lookup ClaimLine to ClaimHeader
        private readonly FdOptumCareHcpClaimLineLookup lookupRawFile;
        private readonly MergeUtilities mergeClmHdrWithClmLnLookup;
        private readonly string claimLineLookupBeforeRollupFile;
        private readonly string claimLineLookupAfterRollupFile;

        ///Rollup Claim Line
        private readonly LookupLineRollup1060 lookupLineRollup;
        private bool isRacer;

        ///Common to all files
        private readonly CountUtilities counts;
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        #endregion DECLARATIONS

        #region CONSTRUCTOR

        public PrepareRollupClaim1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            base.racerLoadJobProperties = racerProps;
            base.LoadRacerVariables();
            InitializeLoadRerun();

            this.adHocClaimHeaderFileName = racerLoadJobProperties.AdHocClaimHeaderFilename;
            this.fdClaimHeader = new FdOptumCareHcpClaim();

            this.claimLineRawFile = new FdOptumCareHcpClaimLine(racerLoadJobProperties);
            this.claimLineFile = racerLoadJobProperties.AdHocClaimHeaderFilename.Replace("File.txt", "FileA.txt");
            this.claimLineLookupBeforeRollupFile = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileA_LookupBeforeRollup.txt");

            this.lookupRawFile = new FdOptumCareHcpClaimLineLookup();
            this.lookupLineRollup = new LookupLineRollup1060();
            this.claimLineLookupAfterRollupFile = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileA_ClaimNoLookup.txt");

            this.mergeClmHdrWithClmLnLookup = new MergeUtilities();
            this.counts = new CountUtilities();
            this.log = new LogUtilities(racerLoadJobProperties);

            this.log.Write("PrepareRollupClaim1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTOR

        #region PREPARE_EXECUTE

        public override bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PrepareClaimLineLookupSort))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    /// Bypass sorting when running unit tests
                    if (!this.racerLoadJobProperties.UseMockRawFiles)
                        SortLookupFile();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareClaimLineLookupSort, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PrepareClaimLineRollup))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    ClaimLineRollup();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareClaimLineRollup, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PrepareClaimLineRollupSort))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    /// Bypass sorting when running unit tests
                    if (!this.racerLoadJobProperties.UseMockRawFiles)
                        SortRollupFile();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareClaimLineRollupSort, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PrepareClaimHeaderMerge))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    SortAndMergeClaimHeaderWithLookup();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareClaimHeaderMerge, 1);
                    this.loadRerun.WriteRerunStats();
                }

                return true;
            }

            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception.StackTrace);
                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }
        }
        #endregion PREPARE_EXECUTE

        #region PRIVATE_METHODS

        private void InitializeLoadRerun()
        {
            this.loadRerun = new LoadRerun(this.racerLoadJobProperties);
            this.loadRerun.Init(Constant.PrepareClaimAdhocFile);
            this.loadRerun.Init(Constant.PrepareClaimAdhocFileA);
            this.loadRerun.Init(Constant.PrepareClaimLineLookupSort);
            this.loadRerun.Init(Constant.PrepareClaimLineRollup);
            this.loadRerun.Init(Constant.PrepareClaimLineRollupSort);
            this.loadRerun.Init(Constant.PrepareClaimHeaderMerge);

            loadRerun.WriteRerunStats();
        }

        private void SortLookupFile()
        {
            var claimLineLookupBeforeRollupSort = new SortUtilities(racerLoadJobProperties);

            claimLineLookupBeforeRollupSort.Clear();
            claimLineLookupBeforeRollupSort.SetFile(this.claimLineLookupBeforeRollupFile, true);
            claimLineLookupBeforeRollupSort.AddSortField(1, Sort.SType.StandardCharacterData, dedupe: false);
            claimLineLookupBeforeRollupSort.AddSortField(2, Sort.SType.DayMonthCenturyDate, dedupe: false);
            claimLineLookupBeforeRollupSort.Sort();
        }

        private void SortRollupFile()
        {
            var claimLineLookupAfterRollupSort = new SortUtilities(racerLoadJobProperties);

            claimLineLookupAfterRollupSort.Clear();
            claimLineLookupAfterRollupSort.SetFile(this.claimLineLookupAfterRollupFile, true);
            claimLineLookupAfterRollupSort.AddSortField(1, Sort.SType.StandardCharacterData);
            claimLineLookupAfterRollupSort.Sort();
        }

        private void SortAndMergeClaimHeaderWithLookup()
        {
            var adhocClaimHeaderFileSort = new SortUtilities(racerLoadJobProperties);
            var adhocClaimHeaderFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdClaimHeader.EmitHeaderLine(false));

            /// Bypass sorting when running unit tests
            if (!this.racerLoadJobProperties.UseMockRawFiles)
            {
                adhocClaimHeaderFileSort.Clear();
                adhocClaimHeaderFileSort.SetFile(this.adHocClaimHeaderFileName, true);
                adhocClaimHeaderFileSort.AddSortField(adhocClaimHeaderFileIndex["CLAIM_NO"], Sort.SType.StandardCharacterData);
                adhocClaimHeaderFileSort.Sort();
            }

            this.mergeClmHdrWithClmLnLookup.Clear();
            this.mergeClmHdrWithClmLnLookup.SetSourceFile(this.claimLineLookupAfterRollupFile, 1);
            this.mergeClmHdrWithClmLnLookup.SetTargetFile(this.adHocClaimHeaderFileName, adhocClaimHeaderFileIndex["CLAIM_NO"]);
            this.mergeClmHdrWithClmLnLookup.AddFieldToMove(2, adhocClaimHeaderFileIndex["DATE_OF_SERVICE_BEG"]);
            this.mergeClmHdrWithClmLnLookup.AddFieldToMove(3, adhocClaimHeaderFileIndex["DATE_OF_SERVICE_END"]);
            this.mergeClmHdrWithClmLnLookup.AddFieldToMove(4, adhocClaimHeaderFileIndex["AMT_BILLED"]);
            this.mergeClmHdrWithClmLnLookup.Merge();
        }
        #endregion PRIVATE_METHODS

        #region ROLLUPS

        /// <summary>
        /// Rolls the adHoc claim file
        /// Reads in the adHoc file and trims the last column(s) in the WriteLine method of the Row Object.
        /// </summary>
        private void ClaimLineRollup()
        {
            try
            {
                int inCount = 0;
                int outCount = 0;

                using (var readLookup = new StreamReader(this.claimLineLookupBeforeRollupFile))
                using (var writeRollup = new StreamWriter(this.claimLineLookupAfterRollupFile))
                {
                    var lookupLine = new FdOptumCareHcpClaimLineLookup();

                    var line = readLookup.ReadLine();
                    ///write header to output file. Set parameter to false to prevent SUB_MEMBER_KEY from being written to file.
                    writeRollup.WriteLine(lookupLine.EmitHeaderLine(false));
                    this.isRacer = true;

                    ///read, rollup, write
                    while ((line = readLookup.ReadLine()) != null)
                    {
                        inCount++;
                        ///instantiate new FO for each line to avoid reference issues when storing claimLines in rollup object
                        lookupLine = new FdOptumCareHcpClaimLineLookup();
                        lookupLine.LoadFromString(line);

                        if (this.lookupLineRollup.ClaimNo == lookupLine.CLAIM_NO || string.IsNullOrEmpty(this.lookupLineRollup.ClaimNo))
                        {
                            RollupClaim(lookupLine);
                        }
                        else
                        {

                            WriteClaim(writeRollup);
                            outCount += this.lookupLineRollup.LookupLineList.Count;

                            this.lookupLineRollup.Clear();
                            this.isRacer = true;

                            RollupClaim(lookupLine);
                        }
                    }

                    WriteClaim(writeRollup);
                    outCount += this.lookupLineRollup.LookupLineList.Count;

                    writeRollup?.FlushAndClose();
                }

                this.log.Write($"Completed {this.GetType().Name} Execute");
                this.log.Write($"   Lines read: {inCount}");
                this.log.Write($"   Lines written: {outCount}");
            }

            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception.StackTrace);
                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }

            finally
            {
                File.Delete(this.claimLineLookupBeforeRollupFile);
            }
        }

        private void RollupClaim(FdOptumCareHcpClaimLineLookup lookupLine)
        {
            ///Add ammounts
            if (!string.IsNullOrEmpty(lookupLine.CL_AMT_BILLED))
                lookupLineRollup.Amount_Billed.Add(lookupLine.CL_AMT_BILLED);

            ///add dates of service
            if (!string.IsNullOrEmpty(lookupLine.CL_DATE_OF_SERVICE_BEG))
                this.lookupLineRollup.Date_of_Service_Beg.Add(lookupLine.CL_DATE_OF_SERVICE_BEG);
            if (!string.IsNullOrEmpty(lookupLine.CL_DATE_OF_SERVICE_END))
                this.lookupLineRollup.Date_of_Service_End.Add(lookupLine.CL_DATE_OF_SERVICE_END);

            ///add claim
            this.lookupLineRollup.LookupLineList.Add(lookupLine);
            this.lookupLineRollup.ClaimNo = lookupLine.CLAIM_NO;
        }

        /// <summary>
        /// Write claim lines with accumulated values to output adHocClaimHeaderFile.txt
        /// </summary>
        private void WriteClaim(StreamWriter writer)
        {
            bool firstTime = true;
            var rolledLine = new FdOptumCareHcpClaimLineLookup();

            ///set cLaim_no
            rolledLine.CLAIM_NO = this.lookupLineRollup.ClaimNo;

            ///set dates of service
            rolledLine.CL_DATE_OF_SERVICE_BEG = DateUtilities.GetDate(this.lookupLineRollup.Date_of_Service_Beg.Minimum);
            rolledLine.CL_DATE_OF_SERVICE_END = DateUtilities.GetDate(this.lookupLineRollup.Date_of_Service_End.Maximum);

            ///set amounts
            rolledLine.CL_AMT_BILLED = this.lookupLineRollup.Amount_Billed.Amt.ToString();

            ///write output without lookup fields
            writer.WriteLine(rolledLine.ToString());

            ///RACER PROCESSING - only load AdjustmentTypeCode of O to RACER per CDG.
            if (this.racerLoadJobProperties.RunRacerProcesses && isRacer && firstTime)
            {
                firstTime = false;
            }
        }
        #endregion ROLLUPS
    }
}
