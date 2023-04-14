namespace PE___Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Root of the tree
            TalentTreeNode root = new TalentTreeNode("Magic", true);

            // Left side of the tree
            root.Left = new TalentTreeNode("Fireball", true);
            root.Left.Left = new TalentTreeNode("Crazy Big Fireball", false);
            root.Left.Right = new TalentTreeNode("1000 Tiny Fireballs", true);

            // Right side of the tree
            root.Right = new TalentTreeNode("Magic Arrow", false);
            root.Right.Left = new TalentTreeNode("Ice Arrow", false);
            root.Right.Right = new TalentTreeNode("Exploding Arrow", false);



            // Check recursive methods
            Console.WriteLine("---Listing all abilities---");
            root.ListAllAbilities();
            
            Console.WriteLine("\n---Listing all known abilities---");
            root.ListKnownAbilities();

            Console.WriteLine("\n---Listing all abilities I could learn next---");    
            root.ListPossibleAbilities();
        }
    }
}