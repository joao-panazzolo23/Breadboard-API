using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.EntityMapper;

public interface IBaseMapper
{
    public void Apply(ModelBuilder builder);
}