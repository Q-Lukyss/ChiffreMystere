namespace FirstApp
{
    public class MysteryNumber
    {
        private int numberToGuess;
        private int count;
        private bool gameState;

        private readonly Action<string> updateGameState;
        private readonly Action<string, bool> updateResult;

        public MysteryNumber(Action<string> updateGameState, Action<string, bool> updateResult)
        {
            this.updateGameState = updateGameState;
            this.updateResult = updateResult;
        }

        public void SetNumber()
        {
            Random aleatoire = new Random();
            this.numberToGuess = aleatoire.Next(10);
            this.count = 0;
            this.gameState = true;
        }

        public void ParseInput(string inputPlayer)
        {
            try
            {
                int nombrePlayer = int.Parse(inputPlayer);
                if (nombrePlayer < 0 || nombrePlayer > 9)
                {
                    throw new NombreException();
                }
                HandleInput(nombrePlayer);
            }
            catch (FormatException)
            {
                updateResult("Erreur : J'ai dit un chiffre.", false);
            }
            catch (NombreException e)
            {
                updateResult(e.Message, false);
            }
        }

        public void HandleInput(int nombrePlayer)
        {
            IncrementCounter();
            if (nombrePlayer < this.numberToGuess)
            {
                updateResult("Le chiffre à trouver est supérieur.", false);
            }
            else if (nombrePlayer == this.numberToGuess)
            {
                updateResult($"Félicitations ! Le chiffre à trouver était {this.numberToGuess} !", true);
            }
            else
            {
                updateResult("Le chiffre à trouver est inférieur.", false);
            }
        }

        private void IncrementCounter()
        {
            this.count++;
        }
        public int GetCounter() { return this.count; }
    }
}
