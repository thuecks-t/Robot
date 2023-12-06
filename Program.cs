namespace RobotCaveFightTestArena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create bots
            TrainingDummy trainingDummy = new TrainingDummy();
            TrainingDummy trainingDummy1 = new TrainingDummy();
            BloodIron bloodIron = new BloodIron();
            BloodIron bloodIron1 = new BloodIron();
            bloodIron1.RobotName = "Practice Bot";


            //Create a new arena
            Arena arena = new Arena(bloodIron1, bloodIron);

            arena.RunBattle();
        }
    }
}