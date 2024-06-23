using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend.Exchange.Domain.Model.Aggregates;

public partial class Offer : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}