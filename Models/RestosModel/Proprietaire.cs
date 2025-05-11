namespace RestoManager_Marwa.Models.RestosModel
{
    public class Proprietaire
       
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public ICollection<Restaurant> LesRestos { get; set; }

        //public virtual Proprietaire? LesRestos { get; set; }
    }
}
