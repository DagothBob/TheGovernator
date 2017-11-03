using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System;
using Android.Content.Res;

namespace TheGovernator
{
    [Activity(Label = "TheGovernator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected const string SAVE_SELECTION = "";

        protected int current_selection = 0;

        // Do not access these by name - use buttons array + the index
        // They are added to the array in this order (littlefriend is 0, likehome 1, etc.)
        protected ImageView button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello, background;

        protected ImageView[] buttons;

        protected int[,] backgrounds;

        protected MediaPlayer playerSE;

        protected const String SE_TEST = "Resources/raw/SE_test.mp3";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Console.WriteLine("DEBUG: CONSOLE.WRITELINE TEST");

            // Attaching objects to their views
            button_chocolates = FindViewById<ImageView>(Resource.Id.button_chocolates);
            button_littlefriend = FindViewById<ImageView>(Resource.Id.button_littlefriend);
            button_likehome = FindViewById<ImageView>(Resource.Id.button_likehome);
            button_itsme = FindViewById<ImageView>(Resource.Id.button_itsme);
            button_deadpeople = FindViewById<ImageView>(Resource.Id.button_deadpeople);
            button_dreams = FindViewById<ImageView>(Resource.Id.button_dreams);
            button_neverhungry = FindViewById<ImageView>(Resource.Id.button_neverhungry);
            button_wakeup = FindViewById<ImageView>(Resource.Id.button_wakeup);
            button_gohome = FindViewById<ImageView>(Resource.Id.button_gohome);
            button_theforce = FindViewById<ImageView>(Resource.Id.button_theforce);
            button_precious = FindViewById<ImageView>(Resource.Id.button_precious);
            button_hello = FindViewById<ImageView>(Resource.Id.button_hello);

            // Access buttons through this array after this line!
            buttons = new ImageView[] { button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello };

            // Access backgrounds through this 2D array after this line!
            // First index is standard ID for the quote
            // Second index is 0 for landscape, 1 for portrait
            backgrounds = new int[,] { { Resource.Drawable.little_friend_LS, Resource.Drawable.like_home_LS, Resource.Drawable.its_me_LS,
            Resource.Drawable.dead_people_LS, Resource.Drawable.dreams_LS, Resource.Drawable.never_hungry_LS, Resource.Drawable.wake_up_LS,
            Resource.Drawable.chocolates_LS, Resource.Drawable.go_home_LS, Resource.Drawable.force_LS, Resource.Drawable.precious_LS,
            Resource.Drawable.hello_LS }, { Resource.Drawable.little_friend_P, Resource.Drawable.like_home_P, Resource.Drawable.its_me_P,
            Resource.Drawable.dead_people_P, Resource.Drawable.dreams_P, Resource.Drawable.never_hungry_P, Resource.Drawable.wake_up_P,
            Resource.Drawable.chocolates_P, Resource.Drawable.go_home_P, Resource.Drawable.force_P, Resource.Drawable.precious_P,
            Resource.Drawable.hello_P } };

            // Attaching background to its view
            background = FindViewById<ImageView>(Resource.Id.background);

            // Restore saved state
            if (savedInstanceState != null)
            {
                current_selection = savedInstanceState.GetInt(SAVE_SELECTION);
                ChangeSelection(buttons[current_selection], false);
            }
            else
            {
                ChangeSelection(buttons[0], false);
            }

            // Initial background (will not play sound)

            // Setting Button delegates
            button_chocolates.Click += Button_chocolates_Click;
            button_likehome.Click += Button_likehome_Click;
            button_littlefriend.Click += Button_littlefriend_Click;
            button_deadpeople.Click += Button_deadpeople_Click;
            button_itsme.Click += Button_itsme_Click;
            button_dreams.Click += Button_dreams_Click;
            button_neverhungry.Click += Button_neverhungry_Click;
            button_precious.Click += Button_precious_Click;
            button_wakeup.Click += Button_wakeup_Click;
            button_gohome.Click += Button_gohome_Click;
            button_theforce.Click += Button_theforce_Click;
            button_hello.Click += Button_hello_Click;

            playerSE = new MediaPlayer();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(SAVE_SELECTION, current_selection);
        }

        private void Button_hello_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_theforce_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_gohome_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_wakeup_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_precious_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_neverhungry_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_dreams_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_itsme_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_deadpeople_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_littlefriend_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_likehome_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        private void Button_chocolates_Click(object sender, System.EventArgs e)
        {
            StartPlayer(SE_TEST);
        }

        //Plays specified audio file, initializing playerSE as a MediaPlayer object
        //if it hasn't been already
        public void StartPlayer(String filePath)
        {
            Console.WriteLine("DEBUG: STARTPLAYER CALLED");
            AssetFileDescriptor afd = Assets.OpenFd(filePath);
            if (playerSE == null)
            {
                playerSE = new MediaPlayer();
            }
            else
            {
                playerSE.Reset();
                playerSE.SetDataSource(afd.FileDescriptor);
                playerSE.Prepare();
                playerSE.Start();
                Console.WriteLine("DEBUG: PLAYERSE.START()");
            }
        }

        /*  Transition the background
         *  backgroundvalue is 0 - 11 for backgrounds[,]
         *  orientation is 0 for landscape, 1 for portrait in backgrounds[,]  */
        public void ChangeBackground(int backgroundvalue, int orientation)
        {
            // TODO: background.SetImageResource(backgrounds[backgroundvalue, orientation]);
            background.SetImageResource(Resource.Drawable.chocolates_P);
        }

        /*  Actions to perform when a button is selected
         *  bool instantplay is if audio playback should begin when selected  */
        public void ChangeSelection(ImageView selection, bool instantplay)
        { // TODO: Change all SE_TEST to final audio files
            int choiceint = 0;
            if (instantplay)
            {
                // button_littlefriend
                if (selection == buttons[0])
                {
                    choiceint = 0;
                }
                // button_likehome
                else if (selection == buttons[1])
                {
                    choiceint = 1;
                }
                // button_itsme
                else if (selection == buttons[2])
                {
                    choiceint = 2;
                }
                // button_deadpeople
                else if (selection == buttons[3])
                {
                    choiceint = 3;
                }
                // button_dreams
                else if (selection == buttons[4])
                {
                    choiceint = 4;
                }
                // button_neverhungry
                else if (selection == buttons[5])
                {
                    choiceint = 5;
                }
                // button_wakeup
                else if (selection == buttons[6])
                {
                    choiceint = 6;
                }
                // button_chocolates
                else if (selection == buttons[7])
                {
                    choiceint = 7;
                }
                // button_gohome
                else if (selection == buttons[8])
                {
                    choiceint = 8;
                }
                // button_theforce
                else if (selection == buttons[9])
                {
                    choiceint = 9;
                }
                // button_precious
                else if (selection == buttons[10])
                {
                    choiceint = 10;
                }
                // button_hello
                else if (selection == buttons[11])
                {
                    choiceint = 11;
                }
            }
            if (true)
            {
                ChangeBackground(choiceint, 0);
            }
            else
            {
                ChangeBackground(choiceint, 1);
            }
        }
    }
}

