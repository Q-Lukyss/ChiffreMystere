namespace FirstApp
{
    public partial class MainPage : ContentPage
    {
        private MysteryNumber jeu;

        public MainPage()
        {
            InitializeComponent();
            jeu = new MysteryNumber(UpdateGameState, UpdateResult);
            jeu.SetNumber();
        }
        private void OnGuessClicked(object sender, EventArgs e)
        {
            string input = GuessInput.Text;
            jeu.ParseInput(input);
            CountLabel.Text = jeu.GetCounter() + " essai(s)";
        }

        private void OnReplayClicked(object sender, EventArgs e)
        {
            jeu.SetNumber();
            CountLabel.Text = "";
            ResultLabel.Text = "";
            GameStateLabel.Text = "Je vais penser à un chiffre et vous allez essayer de le deviner !!!";
            GuessInput.Text = "";
            GuessInput.IsEnabled = true;
            ReplayButton.IsVisible = false;
        }

        private void UpdateGameState(string message)
        {
            GameStateLabel.Text = message;
        }

        private void UpdateResult(string message, bool gameOver)
        {
            ResultLabel.Text = message;
            if (gameOver)
            {
                GuessInput.IsEnabled = false;
                ReplayButton.IsVisible = true;
            }
        }
    }

}
