namespace RestoManager_Marwa.Models.RestosModel
{
    public class Restaurant
    {
        public string CodeResto { get; set; }
        public string NomResto { get; set; }
        public string Specialite { get; set; }
        public string Ville { get; set; }
        public string Tel { get; set; }

        public string NumProp { get; set; }  // <- was int, should be string
        public Proprietaire LeProprio { get; set; }
        public ICollection<Avis> LesAvis { get; set; } = new List<Avis>();
    }

}
