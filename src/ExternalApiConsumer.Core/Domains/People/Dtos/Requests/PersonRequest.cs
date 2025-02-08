using System.ComponentModel.DataAnnotations;

namespace ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;

public record PersonRequest(
    [Required(ErrorMessage = "firsName is a required field!")]
    [MinLength(2, ErrorMessage = "firstName must have at least 1 character!")]
    [MaxLength(100, ErrorMessage = "firstName can not exceed 100 charatcers!")]
    string FirstName,
    [Required(ErrorMessage = "latsName is a required field!")]
    [MinLength(2, ErrorMessage = "latsName must have at least 1 character!")]
    [MaxLength(100, ErrorMessage = "latsName can not exceed 100 charatcers!")]
    string LastName,
    [Required(ErrorMessage = "address is a required field!")]
    [MinLength(2, ErrorMessage = "address must have at least 1 character!")]
    [MaxLength(100, ErrorMessage = "address can not exceed 100 charatcers!")]
    string Address
);