// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

#region Payer1060
#region CONSTANTS
[assembly: SuppressMessage("Minor Code Smell", "S2386:Mutable fields should not be \"public static\"",
                            Justification = "Invalid message. leaving code as is for possible future child projects",
                            Scope = "type",
                            Target = "~T:Novus.Payer1060.BusinessObjects.Constants.Constant")]
#endregion CONSTANTS

#region FILE OBJECTS
///claim
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpClaim.LoadFromRaw(System.String)")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpClaim.LoadFromFieldsArray")]
///claimline
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpClaimLine.LoadFromRaw(System.String)")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpClaimLine.LoadFromFieldsArray")]
///diag
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpDiag.LoadFromRaw(System.String)")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpDiag.LoadFromFieldsArray")]
///member
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpMem.LoadFromRaw(System.String)")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpMem.LoadFromFieldsArray")]
///proc
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpProc.LoadFromRaw(System.String)")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpProc.LoadFromFieldsArray")]
///provider
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpProvider.LoadFromRaw(System.String)")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.FdOptumCareHcpProvider.LoadFromFieldsArray")]
///lookup diagproc
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.LookupDiagProcToIcdMapper.LoadFromFieldsArray")]
[assembly: SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high",
                            Justification = "It is common for our FileObject classes to contain more than 30 objects.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.LookupDiagProcToIcdMapper.LoadFromRaw(System.String)")]
///looup diag to claim
[assembly: SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed",
                            Justification = "Needed to increment fields.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.BusinessObjects.FileObjects.LookupDiagToClaimFields.LoadFromString(System.String[])")]
#endregion FILE OBJECTS

#region PREPARE CLAIM
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.claimLineRawFile")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.claimLineFile")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.lookupRawFile")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.mergeClmHdrWithClmLnLookup")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.counts")]
[assembly: SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed",
                            Justification = "Invalid message. Variable is used in the while loop.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareRollupClaim1060.ClaimLineRollup")]
[assembly: SuppressMessage("Major Code Smell", "S2589:Boolean expressions should not be gratuitous",
                            Justification = "Only load AdjustmentTypeCode of O to RACER per CDG",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareRollupClaim1060.WriteClaim(System.IO.StreamWriter)")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message. Value is being reset. Statement needed.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareRollupClaim1060.WriteClaim(System.IO.StreamWriter)")]
[assembly: SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed",
                            Justification = "Invalid message. Value is being reset. Statement needed.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareRollupClaim1060.WriteClaim(System.IO.StreamWriter)")]
#endregion PREPARE CLAIM

#region PREPARE ROLLUP CLAIM
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "<Invalid message. Field is used.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.claimLineRawFile")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "<Invalid message. Field is used.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.claimLineFile")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "<Invalid message. Field is used.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.lookupRawFile")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "<Invalid message. Field is used.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareRollupClaim1060.counts")]
[assembly: SuppressMessage("Style", "IDE0017:Simplify object initialization",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareRollupClaim1060.WriteClaim(System.IO.StreamWriter)")]
#endregion PREPARE ROLLUP CLAIM

#region PREPARE MERGE CLAIM
#endregion PREPARE MERGE CLAIM

#region PREPARE ICD
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMergeClaimToIcd1060.icdLookupFile")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMergeClaimToIcd1060.racerIcd")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMergeClaimToIcd1060.racerIcd")]
[assembly: SuppressMessage("Blocker Bug", "S2930:\"IDisposables\" should be disposed",
                            Justification = "Writer is disposed in Execute Override",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareMergeClaimToIcd1060.#ctor(Novus.Toolbox.RacerLoadJobReadOnlyProperties)")]
#endregion PREPARE ICD

#region PREPARE CLAIM LINE
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed",
                            Justification = "False error. This variable is used throughout the class",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareClaimLine1060.successfulPrepString")]
[assembly: SuppressMessage("Major Code Smell", "S2933:Fields that are only assigned in the constructor should be \"readonly\"",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareClaimLine1060.successfulPrepString")]
#endregion PREPARE CLAIM LINE

#region PREPARE INSURANCE GROUP
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.successfulPrepString")]
[assembly: SuppressMessage("Major Code Smell", "S2933:Fields that are only assigned in the constructor should be \"readonly\"",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.successfulPrepString")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.successfulPrepString")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareInsuranceGroup1060.SortLookupInputInsGroupFile~System.Boolean")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareInsuranceGroup1060.SortMapperOutputInsGroupFile~System.Boolean")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.formatFile")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.fieldMapper")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.sortFactory")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.sortJob")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.isLookupInputFileSorted")]
[assembly: SuppressMessage("Style", "IDE0044:Add readonly modifier",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareInsuranceGroup1060.successfulPrepString")]

#endregion PREPARE INSURANCE GROUP

#region PREPARE PROVIDER
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.successfulPrepString")]
[assembly: SuppressMessage("Major Code Smell", "S2933:Fields that are only assigned in the constructor should be \"readonly\"",
                            Justification = "<PendinInvalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.successfulPrepString")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.formatFile")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.fieldMapper")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.sortFactory")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.sortJob")]
[assembly: SuppressMessage("Style", "IDE0044:Add readonly modifier",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.successfulPrepString")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.successfulPrepString")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareProvider1060.isLookupInputFileSorted")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareProvider1060.SortLookupInputProviderFile~System.Boolean")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareProvider1060.SortMapperOutputProviderFile~System.Boolean")]
#endregion PREPARE PROVIDER

#region PREPARE MEMBER
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.successfulPrepString")]
[assembly: SuppressMessage("Major Code Smell", "S2933:Fields that are only assigned in the constructor should be \"readonly\"",
                            Justification = "<PendinInvalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.successfulPrepString")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.formatFile")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.fieldMapper")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.sortFactory")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.sortJob")]
[assembly: SuppressMessage("Style", "IDE0044:Add readonly modifier",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.successfulPrepString")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.successfulPrepString")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PrepareMember1060.isLookupInputFileSorted")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareMember1060.SortLookupInputMemberFile~System.Boolean")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
                            Justification = "Invalid message.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PrepareMember1060.SortMapperOutputMemberFile~System.Boolean")]
#endregion PREPARE MEMBER

#region PREPROCESS CLAIM
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.adHocClaimHeaderFileName")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.claimLineFile")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.racerClaim")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.racerClaimLine")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.racerInsGroup")]
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.racerSpecialFields")]
[assembly: SuppressMessage("Blocker Bug", "S2930:\"IDisposables\" should be disposed",
                            Justification = "Writers are being disposed in base class through closeAdditionalRacerStreamWriters .",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PreprocessClaim1060.#ctor(Novus.Toolbox.RacerLoadJobReadOnlyProperties)")]
[assembly: SuppressMessage("Minor Code Smell","S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message. Preference issue",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.claimLineLookupBeforeRollupFile")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message. Preference issue",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.diagLookupFile")]
[assembly: SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables",
                            Justification = "Invalid message. Preference issue",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessClaim1060.priorClaimIdLookupFile")]
#endregion PREPROCESS CLAIM

#region PREPROCESS MEMBER
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessMember1060.racerMember")]
[assembly: SuppressMessage("Blocker Bug", "S2930:\"IDisposables\" should be disposed",
                            Justification = "Writers are being disposed in base class through closeAdditionalRacerStreamWriters .",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PreprocessMember1060.#ctor(Novus.Toolbox.RacerLoadJobReadOnlyProperties)")]
#endregion PREPROCESS MEMBER

#region PREPROCESS PROVIDER
[assembly: SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessProvider1060.racerProvider")]
[assembly: SuppressMessage("CodeQuality", "IDE0052:Remove unread private members",
                            Justification = "Invalid message. Field is used in constructor.",
                            Scope = "member",
                            Target = "~F:Novus.Payer1060.PreprocessProvider1060.racerProvider")]
[assembly: SuppressMessage("Blocker Bug", "S2930:\"IDisposables\" should be disposed",
                            Justification = "Writers are being disposed in base class through closeAdditionalRacerStreamWriters .",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.PreprocessProvider1060.#ctor(Novus.Toolbox.RacerLoadJobReadOnlyProperties)")]
#endregion PREPROCESS PROVIDER

#region PROPERTIES
[assembly: SuppressMessage("Minor Code Smell", "S1128:Unused \"using\" should be removed",
                            Justification = "needed for build server")]
#endregion PROPERTIES

#region LOADRACER
[assembly: SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed",
                            Justification = "Needed for Base class execution.",
                            Scope = "member",
                            Target = "~M:Novus.Payer1060.ClaimIdPostProcess1060.Execute~System.Boolean")]
#endregion LOADRACER
#endregion Payer1060
