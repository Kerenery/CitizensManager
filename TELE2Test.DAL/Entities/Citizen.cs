using TELE2Test.DAL.Tools;

namespace TELE2Test.DAL.Entities;

public class Citizen
{
    public string Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    public SexType Sex { get; set; }
}