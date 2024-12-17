namespace Saic.Models.Repositories
{
    public interface ISwitchRepository
    {        
        IQueryable<Switch> Switches { get; }

        bool SaveSwitch(Switch s);
        bool CreateSwitch(Switch s);
        bool DeleteSwitch(Switch s);
    }
}