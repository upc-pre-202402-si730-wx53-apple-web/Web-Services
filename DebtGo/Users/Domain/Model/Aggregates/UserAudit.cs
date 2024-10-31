using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;


namespace DebtGo.Users.Domain.Model.Aggregates;

public class UserAudit :  IEntityWithCreatedUpdatedDate
{
[Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
[Column("UpdateAt")] public DateTimeOffset? UpdateDate { get; set; }
}