using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System;
using System.Collections.Generic;
using System.Threading;
using Android.Views;

namespace TheGovernator
{
    [Activity(Label = "The Governator")]
    public class MainActivity : Activity
    {
        protected const string SAVE_SELECTION = "";

        protected int current_selection = 0;

        // Do not access these by name - use buttons array + the index
        // They are added to the array in this order (littlefriend is 0, likehome 1, etc.)
        // This is standard order for all data structures in this app
        protected ImageView button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello, background, backgroundFade, button_play;

        protected ImageView[] buttons;

        protected int[,] backgrounds;

        // Each item in soundEffects has a voice line
        // SE_TEST is for testing purposes only
        protected MediaPlayer playerSE;

        protected Dictionary<int, int> soundEffects;

        protected Thread audiothread;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            ActionBar.Hide();

            ThreadPool.SetMaxThreads(1, 1);

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

            button_play = FindViewById<ImageView>(Resource.Id.button_play);

            // Access buttons through this array after this line!
            buttons = new ImageView[] { button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello };

            // Access backgrounds through this 2D array after this line!
            // First index is 0 for landscape, 1 for portrait
            // Second index is standard ID for the quote
            backgrounds = new int[,] { { Resource.Drawable.little_friend_LS,
                                         Resource.Drawable.like_home_LS,
                                         Resource.Drawable.its_me_LS,
                                         Resource.Drawable.dead_people_LS,
                                         Resource.Drawable.dreams_LS,
                                         Resource.Drawable.never_hungry_LS,
                                         Resource.Drawable.wake_up_LS,
                                         Resource.Drawable.chocolates_LS,
                                         Resource.Drawable.go_home_LS,
                                         Resource.Drawable.force_LS,
                                         Resource.Drawable.precious_LS,
                                         Resource.Drawable.hello_LS }, 
                                       { Resource.Drawable.little_friend_P,
                                         Resource.Drawable.like_home_P,
                                         Resource.Drawable.its_me_P,
                                         Resource.Drawable.dead_people_P,
                                         Resource.Drawable.dreams_P,
                                         Resource.Drawable.never_hungry_P,
                                         Resource.Drawable.wake_up_P,
                                         Resource.Drawable.chocolates_P,
                                         Resource.Drawable.go_home_P,
                                         Resource.Drawable.force_P,
                                         Resource.Drawable.precious_P,
                                         Resource.Drawable.hello_P } };

            // Access sounds through this Dictionary after this line!
            soundEffects = new Dictionary<int, int>
            {
                { 0, Resource.Raw.littlefriend },
                { 1, Resource.Raw.likehome },
                { 2, Resource.Raw.itsme },
                { 3, Resource.Raw.deadpeople },
                { 4, Resource.Raw.dreams },
                { 5, Resource.Raw.neverhungry },
                { 6, Resource.Raw.wakeup },
                { 7, Resource.Raw.chocolates },
                { 8, Resource.Raw.gohome },
                { 9, Resource.Raw.theforce },
                { 10, Resource.Raw.precious },
                { 11, Resource.Raw.hello }
            };

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

            // Setting Button click delegates
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

            button_play.Click += Button_play_Click;

            // Setting button touch delegates
            button_chocolates.Touch += Button_chocolates_Touch;
            button_likehome.Touch += Button_likehome_Touch;
            button_littlefriend.Touch += Button_littlefriend_Touch;
            button_deadpeople.Touch += Button_deadpeople_Touch;
            button_itsme.Touch += Button_itsme_Touch;
            button_dreams.Touch += Button_dreams_Touch;
            button_neverhungry.Touch += Button_neverhungry_Touch;
            button_precious.Touch += Button_precious_Touch;
            button_wakeup.Touch += Button_wakeup_Touch;
            button_gohome.Touch += Button_gohome_Touch;
            button_theforce.Touch += Button_theforce_Touch;
            button_hello.Touch += Button_hello_Touch;

            button_play.Touch += Button_play_Touch;
        }

        private void Button_play_Touch(object sender, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_play_Click(sender, e);
                button_play.SetImageResource(Resource.Drawable.play_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_play.SetImageResource(Resource.Drawable.play_icon);
        }

        // Visual feedback on button presses
        private void Button_chocolates_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_chocolates_Click(sender, e);
                button_chocolates.SetImageResource(Resource.Drawable.chocolates_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_chocolates.SetImageResource(Resource.Drawable.chocolates_icon);
        }

        private void Button_likehome_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_likehome_Click(sender, e);
                button_likehome.SetImageResource(Resource.Drawable.like_home_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_likehome.SetImageResource(Resource.Drawable.like_home_icon);
        }

        private void Button_littlefriend_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_littlefriend_Click(sender, e);
                button_littlefriend.SetImageResource(Resource.Drawable.little_friend_icon_X);
            }
            if (e.Event.Action == MotionEventActions.Up)
                button_littlefriend.SetImageResource(Resource.Drawable.little_friend_icon);
        }

        private void Button_deadpeople_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_deadpeople_Click(sender, e);
                button_deadpeople.SetImageResource(Resource.Drawable.dead_people_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_deadpeople.SetImageResource(Resource.Drawable.dead_people_icon);
        }

        private void Button_itsme_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_itsme_Click(sender, e);
                button_itsme.SetImageResource(Resource.Drawable.its_me_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_itsme.SetImageResource(Resource.Drawable.its_me_icon);
        }

        private void Button_dreams_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_dreams_Click(sender, e);
                button_dreams.SetImageResource(Resource.Drawable.dreams_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_dreams.SetImageResource(Resource.Drawable.dreams_icon);
        }

        private void Button_neverhungry_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_neverhungry_Click(sender, e);
                button_neverhungry.SetImageResource(Resource.Drawable.never_hungry_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_neverhungry.SetImageResource(Resource.Drawable.never_hungry_icon);
        }

        private void Button_precious_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_precious_Click(sender, e);
                button_precious.SetImageResource(Resource.Drawable.precious_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_precious.SetImageResource(Resource.Drawable.precious_icon);
        }

        private void Button_wakeup_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_wakeup_Click(sender, e);
                button_wakeup.SetImageResource(Resource.Drawable.wake_up_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_wakeup.SetImageResource(Resource.Drawable.wake_up_icon);
        }

        private void Button_gohome_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_gohome_Click(sender, e);
                button_gohome.SetImageResource(Resource.Drawable.go_home_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_gohome.SetImageResource(Resource.Drawable.go_home_icon);
        }

        private void Button_theforce_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_theforce_Click(sender, e);
                button_theforce.SetImageResource(Resource.Drawable.force_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_theforce.SetImageResource(Resource.Drawable.force_icon);
        }

        private void Button_hello_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                Button_hello_Click(sender, e);
                button_hello.SetImageResource(Resource.Drawable.hello_icon_X);
            }

            if (e.Event.Action == MotionEventActions.Up)
                button_hello.SetImageResource(Resource.Drawable.hello_icon);
        }

        private void Button_play_Click(object sender, EventArgs e)
        {
            audiothread = new Thread(() => StartPlayer(soundEffects[current_selection]));
            audiothread.Start();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(SAVE_SELECTION, current_selection);
        }

        private void Button_hello_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[11], true);
        }

        private void Button_theforce_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[9], true);
        }

        private void Button_gohome_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[8], true);
        }

        private void Button_wakeup_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[6], true);
        }

        private void Button_precious_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[10], true);
        }

        private void Button_neverhungry_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[5], true);
        }

        private void Button_dreams_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[4], true);
        }

        private void Button_itsme_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[2], true);
        }

        private void Button_deadpeople_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[3], true);
        }

        private void Button_littlefriend_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[0], true);
        }

        private void Button_likehome_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[1], true);
        }

        private void Button_chocolates_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[7], true);
        }

        // Called in audiothread only
        public void StartPlayer(int fileID)
        {
            playerSE = MediaPlayer.Create(this, fileID);
            playerSE.Completion += PlayerSE_Completion;
            playerSE.Error += PlayerSE_Error;

            if (playerSE.IsPlaying)
            {
                playerSE.Stop();
            }

            playerSE.Start();
        }

        private void PlayerSE_Error(object sender, MediaPlayer.ErrorEventArgs e)
        {
            playerSE.Release();
        }

        private void PlayerSE_Completion(object sender, EventArgs e)
        {
            playerSE.Release();
        }

        /*  Transition the background
         *  backgroundvalue is 0 - 11 for backgrounds[,]
         *  orientation is 0 for landscape, 1 for portrait in backgrounds[,]  */
        public void ChangeBackground(int backgroundvalue, int orientation)
        {
            background.SetImageResource(backgrounds[orientation, backgroundvalue]);
        }

        /*  Actions to perform when a button is selected
         *  bool instantplay is if audio playback should begin when selected  */
        public void ChangeSelection(ImageView selection, bool instantplay)
        {
            int playchoice = 0; // This assignment shuts up the compiler, it'll never matter
            if (instantplay)
            {
                // button_littlefriend
                if (selection == buttons[0])
                {
                    current_selection = 0;
                    playchoice = (soundEffects[0]);
                }
                // button_likehome
                else if (selection == buttons[1])
                {
                    current_selection = 1;
                    playchoice = (soundEffects[1]);
                }
                // button_itsme
                else if (selection == buttons[2])
                {
                    current_selection = 2;
                    playchoice = (soundEffects[2]);
                }
                // button_deadpeople
                else if (selection == buttons[3])
                {
                    current_selection = 3;
                    playchoice = (soundEffects[3]);
                }
                // button_dreams
                else if (selection == buttons[4])
                {
                    current_selection = 4;
                    playchoice = (soundEffects[4]);
                }
                // button_neverhungry
                else if (selection == buttons[5])
                {
                    current_selection = 5;
                    playchoice = (soundEffects[5]);
                }
                // button_wakeup
                else if (selection == buttons[6])
                {
                    current_selection = 6;
                    playchoice = (soundEffects[6]);
                }
                // button_chocolates
                else if (selection == buttons[7])
                {
                    current_selection = 7;
                    playchoice = (soundEffects[7]);
                }
                // button_gohome
                else if (selection == buttons[8])
                {
                    current_selection = 8;
                    playchoice = (soundEffects[8]);
                }
                // button_theforce
                else if (selection == buttons[9])
                {
                    current_selection = 9;
                    playchoice = (soundEffects[9]);
                }
                // button_precious
                else if (selection == buttons[10])
                {
                    current_selection = 10;
                    playchoice = (soundEffects[10]);
                }
                // button_hello
                else if (selection == buttons[11])
                {
                    current_selection = 11;
                    playchoice = (soundEffects[11]);
                }
                audiothread = new Thread(() => StartPlayer(playchoice));
            }
            if (WindowManager.DefaultDisplay.Orientation == 1 || WindowManager.DefaultDisplay.Orientation == 3)
            {
                ChangeBackground(current_selection, 0);
            }
            else
            {
                ChangeBackground(current_selection, 1);
            }
        }
    }
}

