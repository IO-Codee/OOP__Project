namespace OOP_Project
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int GetQuantity()
        {
            return Quantity;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
