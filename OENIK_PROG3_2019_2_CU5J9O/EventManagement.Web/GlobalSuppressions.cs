// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System;
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File should have header", Justification = "<Pending>")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification", Justification = "<Pending>")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:EventManagement.Web.Controllers.GuestsController.#ctor(EventManagement.Logic.IFactoryLogic,AutoMapper.IMapper)")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>", Scope = "type", Target = "~T:EventManagement.Web.Program")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>", Scope = "type", Target = "~T:EventManagement.Web.Models.MapperFactory")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>", Scope = "member", Target = "~P:EventManagement.Web.Models.GuestListViewModel.ListOfGuests")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:EventManagement.Web.Models.GuestListViewModel.ListOfGuests")]
[assembly: SuppressMessage("Design", "CA1014:Mark assemblies with CLSCompliant", Justification ="<Pending>")]
[assembly: SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "<Pending>", Scope = "type", Target = "~T:EventManagement.Web.Controllers.GuestsApiController.ApiResult")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>", Scope = "member", Target = "~M:EventManagement.Web.Controllers.GuestsApiController.AddOneGuest(EventManagement.Web.Models.Guest)~EventManagement.Web.Controllers.GuestsApiController.ApiResult")]
