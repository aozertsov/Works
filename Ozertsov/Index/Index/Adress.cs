namespace Adress
{
    class Adress
    {
        public string Street;
        public string City;
        public string Region;
        public int House;
        public int Flat;
        public string SName;
        public string FName;
        public int Index;
        public Adress(string Reg, string Cit, string Str, int Hous, int Fla, string FNam, string SNam, int Ind)
        {
            Region = Reg;
            City = Cit;
            Street = Str;
            House = Hous;
            Flat = Fla;
            FName = FNam;
            SName = SNam;
            Index = Ind;
        }
    }
}
