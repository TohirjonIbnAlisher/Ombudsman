using Ombudsman.BizLogic.Exceptions;

namespace Ombudsman.BizLogic.Validations;

internal static class ServiceValidation<TEntity> where TEntity : class
{
    private readonly static string[] entityName = typeof(TEntity).ToString().Split('.').TakeLast(1).ToArray();
    internal static void CheckingEntityById(TEntity entity)
    {
        if (entity is null)
        {
            throw new StatusCodeException(
                 System.Net.HttpStatusCode.NotFound, $"{string.Join(' ', entityName)} was not found!");
        }
    }
}
