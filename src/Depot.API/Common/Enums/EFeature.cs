using System.ComponentModel.DataAnnotations;

namespace Depot.API.Common.Enums;

public enum EFeature
{
    [Display(Name = "Registrations")]
    Registrations = 0,

    [Display(Name = "Financial")]
    Financial = 1,

    [Display(Name = "Stocks")]
    Stocks = 2,

    [Display(Name = "Endpoints")]
    Endpoints = 3,
}
