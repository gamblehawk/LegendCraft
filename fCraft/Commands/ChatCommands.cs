// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
using System;
using System.Collections.Generic;
using System.Linq;

namespace fCraft
{
    static class ChatCommands
    {
        const int PlayersPerPage = 20;

        public static void Init()
        {
            CommandManager.RegisterCommand(CdSay);
            CommandManager.RegisterCommand(CdStaff);

            CommandManager.RegisterCommand(CdIgnore);
            CommandManager.RegisterCommand(CdUnignore);

            CommandManager.RegisterCommand(CdMe);

            CommandManager.RegisterCommand(CdRoll);

            CommandManager.RegisterCommand(CdDeafen);

            CommandManager.RegisterCommand(CdClear);

            CommandManager.RegisterCommand(CdTimer);

            CommandManager.RegisterCommand(cdReview);
            CommandManager.RegisterCommand(CdAdminChat);
            CommandManager.RegisterCommand(CdCustomChat);
            CommandManager.RegisterCommand(cdAway);
            CommandManager.RegisterCommand(CdHigh5);
            CommandManager.RegisterCommand(CdPoke);
            CommandManager.RegisterCommand(CdBroMode);
            CommandManager.RegisterCommand(CdRageQuit);
            CommandManager.RegisterCommand(CdQuit);
            CommandManager.RegisterCommand(CdModerate);

            CommandManager.RegisterCommand(CdBroFist);
            CommandManager.RegisterCommand(CdGive);
            CommandManager.RegisterCommand(CdJelly);
            CommandManager.RegisterCommand(CdMad);
            CommandManager.RegisterCommand(CdBanHammer);
            CommandManager.RegisterCommand(CdCredits);
            CommandManager.RegisterCommand(CdSTFU);
            CommandManager.RegisterCommand(CdFortuneCookie);
            CommandManager.RegisterCommand(CdLeBot);
            CommandManager.RegisterCommand(CdCalculator);
            CommandManager.RegisterCommand(CdGPS);


            Player.Moved += new EventHandler<Events.PlayerMovedEventArgs>(Player_IsBack);
        }
        #region LegendCraft
        /* Copyright (c) <2012> <LeChosenOne, DingusBingus>
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

        static readonly CommandDescriptor CdGPS = new CommandDescriptor
        {
            Name = "GPS",
            Category = CommandCategory.Chat,
            Permissions = new Permission[] { Permission.Chat },
            IsConsoleSafe = false,
            Usage = "/GPS",
            Help = "Displays your coordinates.",
            NotRepeatable = true,
            Handler = GPSHandler,
        };

        static void GPSHandler(Player player, Command cmd)
        {
            LegendCraft.coords(player);
        }

        #region Calculator
        static readonly CommandDescriptor CdCalculator = new CommandDescriptor
        {
            Name = "Calculator",
            Aliases = new[] { "Calc" },
            Category = CommandCategory.Chat | CommandCategory.Math,
            Permissions = new Permission[] { Permission.Chat },
            IsConsoleSafe = true,
            Usage = "/Calculator [number] [+ or -] [number]",
            Help = "Lets you use a simple calculator in minecraft. Valid options are [ + , - , * , and / ].",
            NotRepeatable = false,
            Handler = CalcHandler,
        };

        static void CalcHandler(Player player, Command cmd)
        {
            String numberone = cmd.Next();
            String op = cmd.Next();
            String numbertwo = cmd.Next();
            int no1, no2;

            if (numberone == null || numbertwo == null || op == null)
            {
                CdCalculator.PrintUsage(player);
                return;
            }

            if (!int.TryParse(numberone, out no1))
            {
                player.Message("Please choose from a whole number.");
                return;
            }

            if (!int.TryParse(numbertwo, out no2))
            {
                player.Message("Please choose from a whole number.");
                return;
            }


            if (player.Can(Permission.Chat))
            {

                if (numberone != null | op != null | numbertwo != null)
                {


                    if (op == "+" | op == "-" | op == "*" | op == "/")
                    {

                        if (op == "+")
                        {
                            long add = no1 + no2;
                            if (add < 0 | no1 < 0 | no2 < 0)
                            {
                                player.Message("Negative Number Detected, please choose from a whole number.");
                                return;
                            }
                            else
                            {
                                if (add % 2 == 0 | no1 % 2 == 0 | no2 % 2 == 0)
                                {
                                    player.Message("&0Calculator: &e{0}+{1}={2}", no1, no2, add);
                                }
                                else
                                {
                                    player.Message("Answer is not a whole number. Please make sure both integers being added are whole numbers.");
                                    return;
                                }
                            }
                        }
                        if (op == "-")
                        {
                            long subtr = no1 - no2;
                            if (subtr < 0 | no1 < 0 | no2 < 0)
                            {
                                player.Message("Negative Number Detected, please choose from a whole number.");
                                return;
                            }
                            else
                            {
                                if (subtr % 2 == 0 | no1 % 2 == 0 | no2 % 2 == 0)
                                {
                                    player.Message("&0Calculator: &e{0}-{1}={2}", no1, no2, subtr);
                                }
                                else
                                {
                                    player.Message("Answer is not a whole number. Please make sure both integers being subtracted are whole numbers.");
                                    return;
                                }
                            }
                        }
                        if (op == "*")
                        {

                            long mult = no1 * no2;
                            if (mult < 0 | no1 < 0 | no2 < 0)
                            {
                                player.Message("Negative Number Detected, please choose from a whole number.");
                                return;
                            }
                            else
                            {
                                if (mult % 2 == 0 | no1 % 2 == 0 | no2 % 2 == 0)
                                {
                                    player.Message("&0Calculator: &e{0}*{1}={2}", no1, no2, mult);
                                }
                                else
                                {
                                    player.Message("Answer is not a whole number. Please make sure both integers being multiplied are whole numbers.");
                                    return;
                                }
                            }
                        }
                        if (op == "/")
                        {

<<<<<<< HEAD
                                long div = no1 / no2;
                                if (div < 0 | no1 < 0 | no2 < 0)
                                {
                                    player.Message("Negative Number Detected, please choose froma  whole number.");
                                    return;
                                }
                                else
=======
                            long div = no1 / no2;
                            if (div < 0 | no1 < 0 | no2 < 0)
                            {
                                player.Message("Negative Number Detected, please choose froma whole number.");
                                return;
                            }
                            else
                            {
                                if (no1 % 2 == 0 | no2 % 2 == 0)
>>>>>>> e64899f2e75dffcf0d5adc9b0585daedf75b41a3
                                {
                                    if (no1 % no2 == 0)
                                    {
                                        player.Message("&0Calculator: &e{0}/{1}={2}", no1, no2, div);
                                    }
                                    else
                                    {
                                        player.Message("&0Calculator: &e{0}/{1}={2}, rounded", no1, no2, div);
                                    }
                                }
                                else
                                {
                                    player.Message("Answer is not a whole number. Please make sure both integers being divided are whole numbers.");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        player.Message("Invalid Operator. Please choose from '+' , '-' , '*' , or '/'");
                        return;
                    }
                }
                else
                {
                    CdCalculator.PrintUsage(player);
                }
            }

        }



        #endregion

        #region LeBot
        static readonly CommandDescriptor CdLeBot = new CommandDescriptor
        {
            Name = "LeBot",
            Aliases = new[] { "lb" },
            Category = CommandCategory.Chat | CommandCategory.Fun,
            Permissions = new Permission[] { Permission.LeBot },
            IsConsoleSafe = false,
            Usage = "/LeBot Option",
            Help = "LegendCraft Bot. Options are [help], [spleef], [go], [server], [joke], [time], [promos], [bans], [kicks], [players], [blocks], and [funfact].",
            NotRepeatable = true,
            Handler = LeBotHandler,
        };

        static void LeBotHandler(Player player, Command cmd)
        {
            String option = cmd.Next();
            double LeTime = (DateTime.Now - player.Info.LastUsedLeBot).TotalSeconds;
            if (LeTime < 5)
            {
                double LeftOverTime = Math.Round(5 - LeTime);
                if (LeftOverTime == 1)
                {
                    player.Message("&WYou can use /LeBot again in 1 second.");
                    return;
                }
                else
                {
                    player.Message("&WYou can use /LeBot again in" + LeftOverTime + "seconds");
                }
            }
            if (option == null)
            {
                player.Message("LegendCraft Bot. Options are [help], [spleef], [go], [server], [joke], [time], [promos], [bans], [kicks], [players], [blocks], and [funfact].");
                return;
            }
            else if (option == "help")
            {
                player.Message("Spleef: Sets a 3 second timer for 'spleef.'\n" +
                    "Go: Sets a 5 second timer for 'go.'\n" +
                    "Server: Displays the server name.\n" +
                    "Joke: Displays a joke.\n" +
                    "Time: Displays the users total time on the server.\n" +
                    "Promos: Displays the amount of players the user has promote.d\n" +
                    "Bans: Displays the amount of players the user has banned.\n" +
                    "Kicks: Displays the amount of players the user has kicked.\n" +
                    "Blocks: Displays the amount of blocks the user has modified.\n" +
                    "Funfact: Displays a funfact.\n");
            }

            else if (option == "go")
            {
                Server.Message("{0}&f: LeBot, Go", player.ClassyName);
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 5")).RunOnce(TimeSpan.FromSeconds(0));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 4")).RunOnce(TimeSpan.FromSeconds(1));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 3")).RunOnce(TimeSpan.FromSeconds(2));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 2")).RunOnce(TimeSpan.FromSeconds(3));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 1")).RunOnce(TimeSpan.FromSeconds(4));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: Go!")).RunOnce(TimeSpan.FromSeconds(5));
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "spleef")
            {
                Server.Message("{0}&f: LeBot, Spleef", player.ClassyName);
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 3")).RunOnce(TimeSpan.FromSeconds(0));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 2")).RunOnce(TimeSpan.FromSeconds(1));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: 1")).RunOnce(TimeSpan.FromSeconds(2));
                Scheduler.NewTask(t => Server.Message("&0LeBot&f: Spleef!")).RunOnce(TimeSpan.FromSeconds(3));
                player.Info.LastUsedLeBot = DateTime.Now;
            }

            else if (option == "server")
            {
                Server.Message("{0}&f: LeBot, Server", player.ClassyName);
                Server.Message("&0LeBot&f: The name of this server is " + ConfigKey.ServerName.GetString() + ".");
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "joke")
            {
                Server.Message("{0}&f: LeBot, Joke", player.ClassyName);
                string[] jokeStrings = { "&fEnergizer Bunny was arrested, charged with battery.",
                                      "&fI usually take steps to avoid elevators.",
                                      "&fSchrodinger's Cat: Wanted dead and alive.",
                                      "&fIf at first you don't succeed; call it version 1.0",
                                      "&fCONGRESS.SYS Corrupted: Re-boot Washington D.C (Y/n)?",
                                      "&fWe live in a society where pizza gets to your house before the police.",
                                      "&fLight travels faster than sound. This is why some people appear bright until you hear them speak.",
                                      "&fEvening news is where they begin with 'Good evening', and then proceed to tell you why it isn't.",
                                      "&fYou do not need a parachute to skydive. You only need a parachute to skydive twice.",
                                      "&fWhen in doubt, mumble.",
                                      "&fNever hit a man with glasses. Hit him with a baseball bat instead.",
                                      "&fNostalgia isn't what it used to be."};
                Random RandjokeString = new Random();
                Server.Message("&0LeBot&f: " + jokeStrings[RandjokeString.Next(0, jokeStrings.Length)]);
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "time")
            {
                Server.Message("{0}&f: LeBot, Time", player.ClassyName);
                TimeSpan time = TimeSpan.FromHours(player.Info.TotalTime.TotalHours);
<<<<<<< HEAD
                Server.Message("&0LeBot&f: {0}&f has spent a total of " + time.ToMiniString() + " on {1}.", player.ClassyName, ConfigKey.ServerName.GetString());
=======
                Server.Message("&0LeBot&f: {0} &fhas spent a total of " + time.ToMiniString() + " &fon {1}.", player.ClassyName, ConfigKey.ServerName.GetString());
>>>>>>> e64899f2e75dffcf0d5adc9b0585daedf75b41a3
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "promos")
            {
                Server.Message("{0}&f: LeBot, Promos", player.ClassyName);
<<<<<<< HEAD
                Server.Message("&0LeBot&f: {0}&f has promoted " + player.Info.PromoCount.ToString() + " players.", player.ClassyName);
=======
                Server.Message("&0LeBot&f: {0} &fhas promoted " + player.Info.PromoCount.ToString() + " players.", player.ClassyName);
>>>>>>> e64899f2e75dffcf0d5adc9b0585daedf75b41a3
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "bans")
            {
                Server.Message("{0}&f: LeBot, Bans", player.ClassyName);
<<<<<<< HEAD
                Server.Message("&0LeBot&f: {0}&f has banned " + player.Info.TimesBannedOthers.ToString() + " players.", player.ClassyName);
=======
                Server.Message("&0LeBot&f: {0} &fhas banned " + player.Info.TimesBannedOthers.ToString() + " players.", player.ClassyName);
>>>>>>> e64899f2e75dffcf0d5adc9b0585daedf75b41a3
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "kicks")
            {
                Server.Message("{0}&f: LeBot, Kicks", player.ClassyName);
<<<<<<< HEAD
                Server.Message("&0LeBot&f: {0}&f has kicked " + player.Info.TimesKickedOthers.ToString() + " players.", player.ClassyName);
=======
                Server.Message("&0LeBot&f: {0} &fhas kicked " + player.Info.TimesKickedOthers.ToString() + " players.", player.ClassyName);
>>>>>>> e64899f2e75dffcf0d5adc9b0585daedf75b41a3
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "blocks")
            {
                long Mods = player.Info.BlocksDrawn + player.Info.BlocksBuilt + player.Info.BlocksDeleted;
                Server.Message("{0}&f: LeBot, Blocks", player.ClassyName);
                Server.Message("&0LeBot&f: {0} &fhas modified " + Mods + " blocks.", player.ClassyName);
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "funfact")
            {
                Server.Message("{0}&f: LeBot, FunFact", player.ClassyName);
                string[] factStrings = { "&fMaine is the only state in the USA that is one syllable.",
                                      "&fAlmonds are a member of the peach family.",
                                      "&fAn ostrich's eye is bigger than it's brain.",
                                      "&fA dime has 118 ridges around the edge.",
                                      "&fPeanuts are one of the ingredients of dynamite.",
                                      "&fTwo thirds of the world's eggplant is grown in New Jersey.",
                                      "&fNo piece of paper can be folded in half more than 7 times.",
                                      "&fVenus is the only planet that rotates clockwise.",
                                      "&fAmerican Airlines saved $40,000 in 1987 by eliminating 1 olive from each salad served in first-class.",
                                      "&fA duck's quack doesn't echo and no one knows why..",
                                      "&fWomen blink nearly twice as much as men.",
                                      "&fIn 1998, more fast-food employees were murdered on the job than police officers.",
                                      "&fFortune cookies were actually invented in America, in 1918, by Charles Jung.",
                                      "&fTYPEWRITER is the longest word that can be made using the letters only on one row of the keyboard."};
                Random RandfactString = new Random();
                Server.Message("&0LeBot&f: " + factStrings[RandfactString.Next(0, factStrings.Length)]);
                player.Info.LastUsedLeBot = DateTime.Now;
            }
            else if (option == "players")
            {
                string param = cmd.Next();
                Player[] players;
                string qualifier;
                int offset = 0;
                players = Server.Players;
                qualifier = "online";
                
                if (param == null || Int32.TryParse(param, out offset))
                {
                    
                    if (cmd.HasNext)
                    {
                        player.Message("/LeBot players [number]");
                        return;
                    }
                }

                if (players.Length > 0)
                {
                    // Filter out hidden players, and sort
                    Player[] visiblePlayers = players.Where(player.CanSee)
                                                     .OrderBy(p => p, PlayerListSorter.Instance)
                                                     .ToArray();

                    if (visiblePlayers.Length == 0)
                    {
                        Server.Message("&0LeBot&f: There are no players {0}", qualifier);

                    }
                    else if (visiblePlayers.Length <= PlayersPerPage || player.IsSuper)
                    {
                        Server.Message("&S ", "&SThere are {0} players {1}: {2}",
                                                visiblePlayers.Length, qualifier, visiblePlayers.JoinToClassyString());
                    }
                    else
                    {
                        if (offset >= visiblePlayers.Length)
                        {
                            offset = Math.Max(0, visiblePlayers.Length - PlayersPerPage);
                        }
                        Player[] playersPart = visiblePlayers.Skip(offset).Take(PlayersPerPage).ToArray();
                        Server.Message("&S ", "&SPlayers {0}: {1}",
                                                qualifier, playersPart.JoinToClassyString());

                        if (offset + playersPart.Length < visiblePlayers.Length)
                        {
                            Server.Message("&0LeBot&f: Showing {0}-{1} (out of {2}). Next: &H/Lb Players {3}{1}",
                                            offset + 1, offset + playersPart.Length,
                                            visiblePlayers.Length,
                                            (worldName == null ? "" : worldName + " "));
                        }
                        else
                        {
                            Server.Message("&0LeBot&f: Showing players {0}-{1} (out of {2}).",
                                            offset + 1, offset + playersPart.Length,
                                            visiblePlayers.Length);
                        }
                    }
                }
                else
                {
                    Server.Message("&0LeBot&f: There are no players {0}", qualifier);
                }
            }
            else
            {
                player.Message("LegendCraft Bot. Options are [help], [spleef], [go], [server], [joke], [time], [promos], [bans], [kicks], [players], [blocks], and [funfact].");
                return;
            }


        }
        #endregion

        static readonly CommandDescriptor CdFortuneCookie = new CommandDescriptor
        {
            Name = "FortuneCookie",
            Aliases = new[] { "FC", "Fortune" },
            Category = CommandCategory.Chat,
            Permissions = new Permission[] { Permission.Chat },
            IsConsoleSafe = true,
            Usage = "/FortuneCookie",
            Help = "Reads you your fortune",
            NotRepeatable = true,
            Handler = FCHandler,
        };

        static void FCHandler(Player player, Command cmd)
        {
            player.Message("You ate the fortune cookie, here is your fortune!");

            string[] msgStrings = { "&3You will die in your life time.",
                                      "&3Early to bed, early to rise, makes a man healthy, wealthy, and tired.",
                                      "&3About time someone got me out of that stale cookie.",
                                      "&3Ignore previous fortune.",
                                      "&3You are not illiterate.",
                                      "&3Only listen to the fortune cookie. Disregard all other fortune telling units.",
                                      "&3This is not the fortune cookie you are looking for.",
                                      "&3That wasn't actually a cookie you just ate...",
                                      "&3Warning, do not break open or eat your fortune cookie.",
                                      "&3You may still be hungry. Order takeout now.",
                                      "&3There is something you wanted to ask?",
                                      "&3For the last time, I am not a fortune, just a small piece of paper.",
                                      "&3Durka Durka, Muhammed Jihad.",
                                      "&3Just focus on the cookie because this fortune sucks...",
                                      "&3How many people eat the cookie and don't even look at the fortune? I guess you aren't one of those people...",
                                      "&3You know, being a cookie is really crummy.",
                                      "&3A wise man once told me that fortunes are bollocks.",
                                      "&3Focus is the key to being successful in life."};
            Random RandmsgString = new Random();
            player.Message(msgStrings[RandmsgString.Next(0, msgStrings.Length)]);

            string[] numStrings = { " &cLucky Numbers:&e 1,2,3,4,5",
                                      " &cLucky Numbers:&e 0,0,0,0,0",
                                      " &cLucky Numbers:&e .5,0,-1,10035,poop",
                                      " &cLucky Numbers:&e 1,2,1,2,1",
                                      " &cLucky Numbers:&e p,o,o,p,y",
                                      " &cLucky Numbers:&e 18,11,22,36,8",
                                      " &cLucky Numbers:&e 11,7,68,0,0",
                                      " &cLucky Numbers:&e 11,11,11,12,11",
                                      " &cLucky Numbers:&e M,II,XL,IV,V",
                                      " &cLucky Numbers:&e 3,2,1,2,1",
                                      " &cLucky Numbers:&e 8,6,7,5,3,0,9",
                                      " &cLucky Numbers:&e en,tre,sju,sex,femton",
                                      " &cLucky Numbers:&e 1,10,100,1000,10000",
                                      " &cLucky Numbers:&e 19,12,3,45,6",
                                      " &cLucky Numbers:&e 2,4,8,16,32",
                                      " &cLucky Numbers:&e 1,11,12,23,35",
                                      " &cLucky Numbers:&e 1,23,4,17,26",
                                      " &cLucky Numbers:&e 4,9,16,33,46",};
            Random RandnumString = new Random();
            player.Message(numStrings[RandnumString.Next(0, numStrings.Length)]);

        }




        static readonly CommandDescriptor CdSTFU = new CommandDescriptor
        {
            Name = "STFU",
            Aliases = new string[] { "ShutUp", "TrollMute" },
            Category = CommandCategory.Chat | CommandCategory.Fun,
            Permissions = new[] { Permission.STFU },
            IsConsoleSafe = true,
            Usage = "/STFU playername",
            Help = "'Mutes' a player for 999m.",
            NotRepeatable = true,
            Handler = STFUHandler,
        };


        static void STFUHandler(Player player, Command cmd)
        {
            string name = cmd.Next();

            if (name == null) //If no name is given.
            {
                player.Message("Please enter a name");
                return;
            }


            Player target = Server.FindPlayerOrPrintMatches(player, name, false, true);

            if (target == player)
            {
                player.Message("You cannot mute yourself.");
                return;
            }

            if (target == null) return;

            if (player.Can(Permission.Slap, target.Info.Rank))
            { //Broadcasts a server meesage saying the player is muted, even thought they are not.
                Server.Players.CanSee(target).Except(target).Message("&sPlayer {0}&6*&s was muted by {1}&s for 999m.", target.ClassyName, player.ClassyName);
                IRC.PlayerSomethingMessage(player, "muted", target, null);
                target.Message("&sYou were muted by {0}&s for 999m.", player.ClassyName);
                return;
            }
            else //meaning if the player cant use the command
            {
                player.Message("You can only mute players ranked {0}&S or lower", player.Info.Rank.GetLimit(Permission.Mute).ClassyName);
            }
        }



        static readonly CommandDescriptor CdCredits = new CommandDescriptor
        {
            Name = "Credits",
            Aliases = new string[] { "credit" },
            Category = CommandCategory.Chat,
            Permissions = new[] { Permission.Chat },
            IsConsoleSafe = true,
            Usage = "/credits",
            Help = "&8Displays the credits of LegendCraft",
            NotRepeatable = true,
            Handler = CreditsHandler,
        };


        static void CreditsHandler(Player player, Command cmd)
        {
            player.Message(" LegendCraft was developed by LeChosenOne and Dingus. LegendCraft was based off of 800Craft developed by Jonty800, GlennMR, and Lao Tszy. 800Craft was based off of fCraft developed by fragmer. Thanks to everyone who contributed to these softwares. And thank you for using LegendCraft!");
        }
        static readonly CommandDescriptor CdBanHammer = new CommandDescriptor
        {
            Name = "BanHammer",
            Aliases = new string[] { "Bh" },
            Category = CommandCategory.Chat,
            Permissions = new[] { Permission.Ban },
            IsConsoleSafe = false,
            Usage = "/banhammer",
            Help = "&8Activate thou banhammer!.",
            NotRepeatable = true,
            Handler = BanHammerHandler,
        };




        static void BanHammerHandler(Player player, Command cmd)
        {
            Server.Message("{0}&W has activated the &0Banhammer!", player.ClassyName);
        }

        static readonly CommandDescriptor CdBroFist = new CommandDescriptor
        {
            Name = "Brofist",
            Aliases = new string[] { "Bf" },
            Category = CommandCategory.Chat | CommandCategory.Fun,
            Permissions = new[] { Permission.Brofist },
            IsConsoleSafe = true,
            Usage = "/Brofist playername",
            Help = "&8Brofists &Sa given player.",
            NotRepeatable = true,
            Handler = BrofistHandler,
        };




        static void BrofistHandler(Player player, Command cmd)
        {
            string targetName = cmd.Next();
            if (targetName == null)
            {
                player.Message("Enter a playername.");
                return;
            }
            Player target = Server.FindPlayerOrPrintMatches(player, targetName, false, true);
            if (target == null)
            {
                player.MessageNoPlayer(targetName);
                return;
            }
            if (target == player)
            {
                Server.Players.CanSee(target).Except(target).Message("{1}&S just tried to &8Brofist &Sthemsleves...", target.ClassyName, player.ClassyName);
                IRC.PlayerSomethingMessage(player, "brofisted", target, null);
                player.Message("&SYou just tried to &8Brofist &Syourself... That's sad...");
                return;
            }
            Server.Players.CanSee(target).Except(target).Message("{1}&S gave {0}&S a &8Brofist&S.", target.ClassyName, player.ClassyName);
            IRC.PlayerSomethingMessage(player, "brofisted", target, null);
            target.Message("{0}&S's fist met yours for a &8Brofist&S.", player.ClassyName);
        }





        static readonly CommandDescriptor CdMad = new CommandDescriptor
        {
            Name = "Mad",
            Category = CommandCategory.Chat,
            IsConsoleSafe = false,
            Permissions = new[] { Permission.EditPlayerDB },
            Usage = "/mad PlayerName",
            Help = "&SHe mad. (Protip: Use /mad playername again to make the player not mad anymore)>",
            Handler = MadHandler
        };

        static void MadHandler(Player player, Command cmd)
        {
            string targetName = cmd.Next();
            string mad = "mad";

            try
            {
                Player target = Server.FindPlayerOrPrintMatches(player, targetName, false, true);
                if (target == player)
                {
                    player.Message("You can't make yourself mad!");
                    return;
                }
                if (target == null)
                {
                    player.Message("No player found matching {0}!", target.ClassyName);
                    return;
                }
                if (player.Can(Permission.EditPlayerDB, target.Info.Rank))
                {
                    PlayerInfo info = PlayerDB.FindPlayerInfoOrPrintMatches(player, targetName);
                    if (target.Info.isMad == false | target.Info.isJelly == false)
                    {
                        if (info == null) return;
                        string oldDisplayedName = target.Info.DisplayedName;
                        target.Info.DisplayedName = mad;

                        if (oldDisplayedName == null)
                        {
                            Server.Message("&W{0} = mad", info.Name);
                            target.Info.isMad = true;
                        }

                        else
                        {
                            Server.Message("&W{0] = mad",
                                            info.Name);

                        }
                    }
                    else
                    {
                        player.Message("Target's name was reset!");
                        target.Info.isMad = false;
                        target.Info.isJelly = false;
                        target.Info.DisplayedName = target.Info.Name;
                    }
                }
                else
                {
                    player.Message("&W You can only make players mad ranked {0}&W and below", player.Info.Rank.GetLimit(Permission.EditPlayerDB).ClassyName);
                }
            }
            
            catch (ArgumentNullException)
            {
                player.Message("Expected format: /mad playername.");
            }
        }
        static readonly CommandDescriptor CdGive = new CommandDescriptor
        {
            Name = "Give",
            Aliases = new string[] { "lend" },
            Category = CommandCategory.Chat,
            Permissions = new Permission[] { Permission.Teleport },
            RepeatableSelection = true,
            IsConsoleSafe = true,
            Usage = "/Give [playername] [item] [amount]",
            Help = "Gives a player somethin` useful.",
            Handler = Give,
        };

        internal static void Give(Player player, Command cmd)
        {
            string targetName = cmd.Next();
            if (targetName == null)
            {
                player.Message("&WPlease insert a playername");
                return;
            }
            Player target = Server.FindPlayerOrPrintMatches(player, targetName, false, true);
            if (target == null)
            {
                player.MessageNoPlayer(targetName);
                return;
            }
            if (target == player)
            {
                player.Message("&WYou cannot give yourself something.");
                return;
            }
            string item = cmd.Next();
            if (item == null)
            {
                player.Message("&WPlease insert an item.");
                return;
            }
            string itemnumber = cmd.Next();
            if (itemnumber == null)
            {
                player.Message("&WPlease insert the item number.");
                return;
            }
            else
            {
                Server.Players.CanSee(target).Message("{0} &egave {1} &e{2} {3}.", player.ClassyName, target.ClassyName, itemnumber, item);
            }
        }
        static readonly CommandDescriptor CdJelly = new CommandDescriptor
        {
            Name = "Jelly",
            Category = CommandCategory.Chat,
            IsConsoleSafe = false,
            Permissions = new[] { Permission.EditPlayerDB },
            Usage = "/jelly PlayerName",
            Help = "&SHe jelly",
            Handler = JellyHandler
        };

        static void JellyHandler(Player player, Command cmd)
        {
            string targetName = cmd.Next();
            string jelly = "jelly";

            try
            {
                Player target = Server.FindPlayerOrPrintMatches(player, targetName, false, true);
                if (target == player)
                {
                    player.Message("You can't make yourself jealous!");
                    return;
                }
                if (target == null)
                {
                    player.Message("No players found matching {0}", target.ClassyName);
                    return;
                }
                if (player.Can(Permission.EditPlayerDB, target.Info.Rank))
                {
                    PlayerInfo info = PlayerDB.FindPlayerInfoOrPrintMatches(player, targetName);
                    if (info == null) return;
                    string oldDisplayedName = info.DisplayedName;
                    info.DisplayedName = jelly;

                    if (target.Info.isMad == false | target.Info.isJelly == false)
                    {

                        if (oldDisplayedName == null)
                        {
                            Server.Message("&W{0} = Jelly", info.Name);

                        }

                        else
                        {
                            Server.Message("&W{0] = Jelly",
                                        info.Name);

                        }
                    }
                    else
                    {
                        player.Message("Target's name was reset!");
                        target.Info.isJelly = false;
                        target.Info.isMad = false;
                        target.Info.DisplayedName = target.Info.Name;
                    }
                }
                else
                {
                    player.Message("&W You can only make players jelly ranked {0}&W and below", player.Info.Rank.GetLimit(Permission.EditPlayerDB).ClassyName);
                }
            }
            catch (ArgumentNullException)
            {
                player.Message("Expected format: /mad playername.");
            } 
        }

        #endregion

        #region 800Craft

        //Copyright (C) <2012> <Jon Baker, Glenn Mariën and Lao Tszy>

        //This program is free software: you can redistribute it and/or modify
        //it under the terms of the GNU General Public License as published by
        //the Free Software Foundation, either version 3 of the License, or
        //(at your option) any later version.

        //This program is distributed in the hope that it will be useful,
        //but WITHOUT ANY WARRANTY; without even the implied warranty of
        //MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
        //GNU General Public License for more details.

        //You should have received a copy of the GNU General Public License
        //along with this program. If not, see <http://www.gnu.org/licenses/>.



        static readonly CommandDescriptor CdModerate = new CommandDescriptor
        {
            Name = "Moderate",
            Aliases = new[] { "Moderation" },
            Category = CommandCategory.Moderation,
            IsConsoleSafe = true,
            Permissions = new[] { Permission.Moderation },
            Help = "Create a server-wide silence, muting all players until called again.",
            NotRepeatable = true,
            Usage = "/Moderate [Voice / Devoice] [PlayerName]",
            Handler = ModerateHandler
        };

        internal static void ModerateHandler(Player player, Command cmd)
        {
            string Option = cmd.Next();
            if (Option == null)
            {
                if (Server.Moderation)
                {
                    Server.Moderation = false;
                    Server.Message("{0}&W deactivated server moderation, the chat feed is enabled", player.ClassyName);
                    IRC.SendAction(player.ClassyName + " &Sdeactivated server moderation, the chat feed is enabled");
                    Server.VoicedPlayers.Clear();
                }
                else
                {
                    Server.Moderation = true;
                    Server.Message("{0}&W activated server moderation, the chat feed is disabled", player.ClassyName);
                    IRC.SendAction(player.ClassyName + " &Sactivated server moderation, the chat feed is disabled");
                    if (player.World != null)
                    { //console safe
                        Server.VoicedPlayers.Add(player);
                    }
                }
            }
            else
            {
                string name = cmd.Next();
                if (Option.ToLower() == "voice" && Server.Moderation)
                {
                    if (name == null)
                    {
                        player.Message("Please enter a player to Voice");
                        return;
                    }
                    Player target = Server.FindPlayerOrPrintMatches(player, name, false, true);
                    if (target == null) return;
                    if (Server.VoicedPlayers.Contains(target))
                    {
                        player.Message("{0}&S is already voiced", target.ClassyName);
                        return;
                    }
                    Server.VoicedPlayers.Add(target);
                    Server.Message("{0}&S was given Voiced status by {1}", target.ClassyName, player.ClassyName);
                    return;
                }
                else if (Option.ToLower() == "devoice" && Server.Moderation)
                {
                    if (name == null)
                    {
                        player.Message("Please enter a player to Devoice");
                        return;
                    }
                    Player target = Server.FindPlayerOrPrintMatches(player, name, false, true);
                    if (target == null) return;
                    if (!Server.VoicedPlayers.Contains(target))
                    {
                        player.Message("&WError: {0}&S does not have voiced status", target.ClassyName);
                        return;
                    }
                    Server.VoicedPlayers.Remove(target);
                    player.Message("{0}&S is no longer voiced", target.ClassyName);
                    target.Message("You are no longer voiced");
                    return;
                }
                else
                {
                    player.Message("&WError: Server moderation is not activated");
                }
            }
        }

        static readonly CommandDescriptor CdQuit = new CommandDescriptor
        {
            Name = "Quitmsg",
            Aliases = new[] { "quit", "quitmessage" },
            Category = CommandCategory.Chat,
            IsConsoleSafe = false,
            Permissions = new[] { Permission.Chat },
            Usage = "/Quitmsg [message]",
            Help = "Adds a farewell message which is displayed when you leave the server.",
            Handler = QuitHandler
        };

        static void QuitHandler(Player player, Command cmd)
        {
            string Msg = cmd.NextAll();

            if (Msg.Length < 1)
            {
                CdQuit.PrintUsage(player);
                return;
            }

            else
            {
                player.Info.LeaveMsg = "left the server: &C" + Msg;
                player.Message("Your quit message is now set to: {0}", Msg);
            }
        }


        static readonly CommandDescriptor CdRageQuit = new CommandDescriptor
        {
            Name = "Ragequit",
            Aliases = new[] { "rq" },
            Category = CommandCategory.Chat | CommandCategory.Fun,
            IsConsoleSafe = false,
            Permissions = new[] { Permission.RageQuit },
            Usage = "/Ragequit [reason]",
            Help = "An anger-quenching way to leave the server.",
            Handler = RageHandler
        };

        static void RageHandler(Player player, Command cmd)
        {
            string reason = cmd.NextAll();

            if (reason.Length < 1)
            {
                Server.Players.Message("{0} &4Ragequit from the server", player.ClassyName);
                player.Kick(Player.Console, "Ragequit", LeaveReason.RageQuit, false, false, false);
                IRC.SendAction(player.ClassyName + " &4Ragequit from the server");
                return;
            }

            else
            {
                Server.Players.Message("{0} &4Ragequit from the server: &C{1}",
                                player.ClassyName, reason);
                IRC.SendAction(player.ClassyName + " &WRagequit from the server: " + reason);
                player.Kick(Player.Console, reason, LeaveReason.RageQuit, false, false, false);
            }
        }

        static readonly CommandDescriptor CdBroMode = new CommandDescriptor
        {
            Name = "Bromode",
            Aliases = new string[] { "bm" },
            Category = CommandCategory.Chat | CommandCategory.Fun,
            Permissions = new[] { Permission.BroMode },
            IsConsoleSafe = true,
            Usage = "/Bromode",
            Help = "Toggles bromode.",
            Handler = BroMode
        };

        static void BroMode(Player player, Command command)
        {
            if (!fCraft.Utils.BroMode.Active)
            {
                foreach (Player p in Server.Players)
                {
                    fCraft.Utils.BroMode.GetInstance().RegisterPlayer(p);
                }
                fCraft.Utils.BroMode.Active = true;
                Server.Players.Message("{0}&S turned Bro mode on.", player.Info.Rank.Color + player.Name);

                IRC.SendAction(player.Name + " turned Bro mode on.");
            }
            else
            {
                foreach (Player p in Server.Players)
                {
                    fCraft.Utils.BroMode.GetInstance().UnregisterPlayer(p);
                }

                fCraft.Utils.BroMode.Active = false;
                Server.Players.Message("{0}&S turned Bro Mode off.", player.Info.Rank.Color + player.Name);
                IRC.SendAction(player.Name + " turned Bro mode off");
            }
        }

        public static void Player_IsBack(object sender, Events.PlayerMovedEventArgs e)
        {
            if (e.Player.IsAway)
            {
                // We need to have block positions, so we divide by 32
                Vector3I oldPos = new Vector3I(e.OldPosition.X / 32, e.OldPosition.Y / 32, e.OldPosition.Z / 32);
                Vector3I newPos = new Vector3I(e.NewPosition.X / 32, e.NewPosition.Y / 32, e.NewPosition.Z / 32);

                // Check if the player actually moved and not just rotated
                if ((oldPos.X != newPos.X) || (oldPos.Y != newPos.Y) || (oldPos.Z != newPos.Z))
                {
                    Server.Players.Message("{0} &Eis back", e.Player.ClassyName);
                    e.Player.IsAway = false;
                }
            }
        }


        static readonly CommandDescriptor CdCustomChat = new CommandDescriptor
        {
            Name = ConfigKey.CustomChatName.GetString(),
            Category = CommandCategory.Chat,
            Aliases = new[] { ConfigKey.CustomAliasName.GetString() },
            Permissions = new[] { Permission.Chat },
            IsConsoleSafe = true,
            NotRepeatable = true,
            Usage = "/Customname Message",
            Help = "Broadcasts your message to all players allowed to read the CustomChatChannel.",
            Handler = CustomChatHandler
        };

        static void CustomChatHandler(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }

            if (player.DetectChatSpam()) return;

            string message = cmd.NextAll().Trim();
            if (message.Length > 0)
            {
                if (player.Can(Permission.UseColorCodes) && message.Contains("%"))
                {
                    message = Color.ReplacePercentCodes(message);
                }
                Chat.SendCustom(player, message);
            }
        }

        static readonly CommandDescriptor cdAway = new CommandDescriptor
        {
            Name = "Away",
            Category = CommandCategory.Chat,
            Aliases = new[] { "afk" },
            IsConsoleSafe = true,
            Usage = "/away [optional message]",
            Help = "Shows an away message.",
            NotRepeatable = true,
            Handler = Away
        };

        internal static void Away(Player player, Command cmd)
        {
            string msg = cmd.NextAll().Trim();
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }
            if (msg.Length > 0)
            {
                Server.Message("{0}&S &Eis away &9({1})",
                                  player.ClassyName, msg);
                player.IsAway = true;
                return;
            }
            else
            {
                Server.Players.Message("&S{0} &Eis away &9(Away From Keyboard)", player.ClassyName);
                player.IsAway = true;
            }
        }


        static readonly CommandDescriptor CdHigh5 = new CommandDescriptor
        {
            Name = "High5",
            Aliases = new string[] { "H5" },
            Category = CommandCategory.Chat | CommandCategory.Fun,
            Permissions = new Permission[] { Permission.HighFive },
            IsConsoleSafe = true,
            Usage = "/High5 playername",
            Help = "High fives a given player.",
            NotRepeatable = true,
            Handler = High5Handler,
        };

        internal static void High5Handler(Player player, Command cmd)
        {
            string targetName = cmd.Next();
            if (targetName == null)
            {
                CdHigh5.PrintUsage(player);
                return;
            }
            Player target = Server.FindPlayerOrPrintMatches(player, targetName, false, true);
            if (target == null)
                return;
            if (target == player)
            {
                player.Message("&WYou cannot high five yourself.");
                return;
            }
            Server.Players.CanSee(target).Except(target).Message("{0}&S was just &chigh fived &Sby {1}&S", target.ClassyName, player.ClassyName);
            IRC.PlayerSomethingMessage(player, "high fived", target, null);
            target.Message("{0}&S high fived you.", player.ClassyName);
        }

        static readonly CommandDescriptor CdPoke = new CommandDescriptor
        {
            Name = "Poke",
            Category = CommandCategory.Chat | CommandCategory.Fun,
            IsConsoleSafe = true,
            Usage = "/poke playername",
            Help = "&SPokes a Player.",
            NotRepeatable = true,
            Handler = PokeHandler
        };

        internal static void PokeHandler(Player player, Command cmd)
        {
            string targetName = cmd.Next();
            if (targetName == null)
            {
                CdPoke.PrintUsage(player);
                return;
            }
            Player target = Server.FindPlayerOrPrintMatches(player, targetName, false, true);
            if (target == null)
            {
                return;
            }
            if (target.Immortal)
            {
                player.Message("&SYou failed to poke {0}&S, they are immortal", target.ClassyName);
                return;
            }
            if (target == player)
            {
                player.Message("You cannot poke yourself.");
                return;
            }
            if (!Player.IsValidName(targetName))
            {
                return;
            }
            else
            {
                target.Message("&8You were just poked by {0}",
                                  player.ClassyName);
                player.Message("&8Successfully poked {0}", target.ClassyName);
            }
        }

        static readonly CommandDescriptor cdReview = new CommandDescriptor
        {
            Name = "Review",
            Category = CommandCategory.Chat,
            IsConsoleSafe = true,
            Usage = "/review",
            NotRepeatable = true,
            Help = "&SRequest an Op to review your build.",
            Handler = Review
        };

        internal static void Review(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }
            var recepientList = Server.Players.Can(Permission.ReadStaffChat)
                                              .NotIgnoring(player)
                                              .Union(player);
            string message = String.Format("{0}&6 would like staff to check their build", player.ClassyName);
            recepientList.Message(message);
            var ReviewerNames = Server.Players
                                         .CanBeSeen(player)
                                         .Where(r => r.Can(Permission.Promote, player.Info.Rank));
            if (ReviewerNames.Count() > 0)
            {
                player.Message("&WOnline players who can review you: {0}", ReviewerNames.JoinToString(r => String.Format("{0}&S", r.ClassyName)));
                return;
            }
            else
                player.Message("&WThere are no players online who can review you. A member of staff needs to be online.");
        }

        static readonly CommandDescriptor CdAdminChat = new CommandDescriptor
        {
            Name = "Adminchat",
            Aliases = new[] { "ac" },
            Category = CommandCategory.Chat | CommandCategory.Moderation,
            Permissions = new[] { Permission.Chat },
            IsConsoleSafe = true,
            NotRepeatable = true,
            Usage = "/Adminchat Message",
            Help = "Broadcasts your message to admins/owners on the server.",
            Handler = AdminChat
        };

        internal static void AdminChat(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }
            if (DateTime.UtcNow < player.Info.MutedUntil)
            {
                player.Message("You are muted for another {0:0} seconds.",
                                player.Info.MutedUntil.Subtract(DateTime.UtcNow).TotalSeconds);
                return;
            }
            string message = cmd.NextAll().Trim();
            if (message.Length > 0)
            {
                if (player.Can(Permission.UseColorCodes) && message.Contains("%"))
                {
                    message = Color.ReplacePercentCodes(message);
                }
                Chat.SendAdmin(player, message);
            }
        }

        #endregion

        #region Say

        static readonly CommandDescriptor CdSay = new CommandDescriptor
        {
            Name = "Say",
            Category = CommandCategory.Chat,
            IsConsoleSafe = true,
            NotRepeatable = true,
            DisableLogging = true,
            Permissions = new[] { Permission.Chat, Permission.Say },
            Usage = "/Say Message",
            Help = "&SShows a message in special color, without the player name prefix. " +
                   "Can be used for making announcements.",
            Handler = SayHandler
        };

        static void SayHandler(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }

            if (player.DetectChatSpam()) return;

            if (player.Can(Permission.Say))
            {
                string msg = cmd.NextAll().Trim();
                if (msg.Length > 0)
                {
                    Chat.SendSay(player, msg);
                }
                else
                {
                    CdSay.PrintUsage(player);
                }
            }
            else
            {
                player.MessageNoAccess(Permission.Say);
            }
        }

        #endregion


        #region Staff

        static readonly CommandDescriptor CdStaff = new CommandDescriptor
        {
            Name = "Staff",
            Aliases = new[] { "st" },
            Category = CommandCategory.Chat | CommandCategory.Moderation,
            Permissions = new[] { Permission.Chat },
            NotRepeatable = true,
            IsConsoleSafe = true,
            DisableLogging = true,
            Usage = "/Staff Message",
            Help = "Broadcasts your message to all operators/moderators on the server at once.",
            Handler = StaffHandler
        };

        static void StaffHandler(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }

            if (player.DetectChatSpam()) return;

            string message = cmd.NextAll().Trim();
            if (message.Length > 0)
            {
                Chat.SendStaff(player, message);
            }
        }

        #endregion


        #region Ignore / Unignore

        static readonly CommandDescriptor CdIgnore = new CommandDescriptor
        {
            Name = "Ignore",
            Category = CommandCategory.Chat,
            IsConsoleSafe = true,
            Usage = "/Ignore [PlayerName]",
            Help = "&STemporarily blocks the other player from messaging you. " +
                   "If no player name is given, lists all ignored players.",
            Handler = IgnoreHandler
        };

        static void IgnoreHandler(Player player, Command cmd)
        {
            string name = cmd.Next();
            if (name != null)
            {
                if (cmd.HasNext)
                {
                    CdIgnore.PrintUsage(player);
                    return;
                }
                PlayerInfo targetInfo = PlayerDB.FindPlayerInfoOrPrintMatches(player, name);
                if (targetInfo == null) return;

                if (player.Ignore(targetInfo))
                {
                    player.MessageNow("You are now ignoring {0}", targetInfo.ClassyName);
                }
                else
                {
                    player.MessageNow("You are already ignoring {0}", targetInfo.ClassyName);
                }

            }
            else
            {
                PlayerInfo[] ignoreList = player.IgnoreList;
                if (ignoreList.Length > 0)
                {
                    player.MessageNow("Ignored players: {0}", ignoreList.JoinToClassyString());
                }
                else
                {
                    player.MessageNow("You are not currently ignoring anyone.");
                }
                return;
            }
        }


        static readonly CommandDescriptor CdUnignore = new CommandDescriptor
        {
            Name = "Unignore",
            Category = CommandCategory.Chat,
            IsConsoleSafe = true,
            Usage = "/Unignore PlayerName",
            Help = "Unblocks the other player from messaging you.",
            Handler = UnignoreHandler
        };

        static void UnignoreHandler(Player player, Command cmd)
        {
            string name = cmd.Next();
            if (name != null)
            {
                if (cmd.HasNext)
                {
                    CdUnignore.PrintUsage(player);
                    return;
                }
                PlayerInfo targetInfo = PlayerDB.FindPlayerInfoOrPrintMatches(player, name);
                if (targetInfo == null) return;

                if (player.Unignore(targetInfo))
                {
                    player.MessageNow("You are no longer ignoring {0}", targetInfo.ClassyName);
                }
                else
                {
                    player.MessageNow("You are not currently ignoring {0}", targetInfo.ClassyName);
                }
            }
            else
            {
                PlayerInfo[] ignoreList = player.IgnoreList;
                if (ignoreList.Length > 0)
                {
                    player.MessageNow("Ignored players: {0}", ignoreList.JoinToClassyString());
                }
                else
                {
                    player.MessageNow("You are not currently ignoring anyone.");
                }
                return;
            }
        }

        #endregion


        #region Me

        static readonly CommandDescriptor CdMe = new CommandDescriptor
        {
            Name = "Me",
            Category = CommandCategory.Chat,
            Permissions = new[] { Permission.Chat },
            IsConsoleSafe = true,
            NotRepeatable = true,
            DisableLogging = true,
            Usage = "/Me Message",
            Help = "&SSends IRC-style action message prefixed with your name.",
            Handler = MeHandler
        };

        static void MeHandler(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }

            if (player.DetectChatSpam()) return;

            string msg = cmd.NextAll().Trim();
            if (msg.Length > 0)
            {
                Chat.SendMe(player, msg);
            }
            else
            {
                CdMe.PrintUsage(player);
            }
        }

        #endregion


        #region Roll

        static readonly CommandDescriptor CdRoll = new CommandDescriptor
        {
            Name = "Roll",
            Category = CommandCategory.Chat,
            Permissions = new[] { Permission.Chat },
            IsConsoleSafe = true,
            Help = "Gives random number between 1 and 100.\n" +
                   "&H/Roll MaxNumber\n" +
                   "&S Gives number between 1 and max.\n" +
                   "&H/Roll MinNumber MaxNumber\n" +
                   "&S Gives number between min and max.",
            Handler = RollHandler
        };

        static void RollHandler(Player player, Command cmd)
        {
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }

            if (player.DetectChatSpam()) return;

            Random rand = new Random();
            int n1;
            int min, max;
            if (cmd.NextInt(out n1))
            {
                int n2;
                if (!cmd.NextInt(out n2))
                {
                    n2 = 1;
                }
                min = Math.Min(n1, n2);
                max = Math.Max(n1, n2);
            }
            else
            {
                min = 1;
                max = 100;
            }

            int num = rand.Next(min, max + 1);
            Server.Message(player,
                            "{0}{1} rolled {2} ({3}...{4})",
                            player.ClassyName, Color.Silver, num, min, max);
            player.Message("{0}You rolled {1} ({2}...{3})",
                            Color.Silver, num, min, max);
        }

        #endregion


        #region Deafen

        static readonly CommandDescriptor CdDeafen = new CommandDescriptor
        {
            Name = "Deafen",
            Aliases = new[] { "deaf" },
            Category = CommandCategory.Chat,
            IsConsoleSafe = true,
            Help = "Blocks all chat messages from being sent to you.",
            Handler = DeafenHandler
        };

        static void DeafenHandler(Player player, Command cmd)
        {
            if (cmd.HasNext)
            {
                CdDeafen.PrintUsage(player);
                return;
            }
            if (!player.IsDeaf)
            {
                for (int i = 0; i < LinesToClear; i++)
                {
                    player.MessageNow("");
                }
                player.MessageNow("Deafened mode: ON");
                player.MessageNow("You will not see ANY messages until you type &H/Deafen&S again.");
                player.IsDeaf = true;
            }
            else
            {
                player.IsDeaf = false;
                player.MessageNow("Deafened mode: OFF");
            }
        }

        #endregion


        #region Clear

        const int LinesToClear = 30;
        static readonly CommandDescriptor CdClear = new CommandDescriptor
        {
            Name = "Clear",
            UsableByFrozenPlayers = true,
            Category = CommandCategory.Chat,
            Help = "&SClears the chat screen.",
            Handler = ClearHandler
        };

        static void ClearHandler(Player player, Command cmd)
        {
            if (cmd.HasNext)
            {
                CdClear.PrintUsage(player);
                return;
            }
            for (int i = 0; i < LinesToClear; i++)
            {
                player.Message("");
            }
        }

        #endregion


        #region Timer

        static readonly CommandDescriptor CdTimer = new CommandDescriptor
        {
            Name = "Timer",
            Permissions = new[] { Permission.Say },
            IsConsoleSafe = true,
            Category = CommandCategory.Chat,
            Usage = "/Timer <Duration> <Message>",
            Help = "&SStarts a timer with a given duration and message. " +
                   "As the timer counts down, announcements are shown globally. See also: &H/Help Timer Abort",
            HelpSections = new Dictionary<string, string> {
                { "abort", "&H/Timer Abort <TimerID>\n&S" +
                            "Aborts a timer with the given ID number. " +
                            "To see a list of timers and their IDs, type &H/Timer&S (without any parameters)." }
            },
            Handler = TimerHandler
        };

        static void TimerHandler(Player player, Command cmd)
        {
            string param = cmd.Next();

            // List timers
            if (param == null)
            {
                ChatTimer[] list = ChatTimer.TimerList.OrderBy(timer => timer.TimeLeft).ToArray();
                if (list.Length == 0)
                {
                    player.Message("No timers running.");
                }
                else
                {
                    player.Message("There are {0} timers running:", list.Length);
                    foreach (ChatTimer timer in list)
                    {
                        player.Message(" #{0} \"{1}&S\" (started by {2}, {3} left)",
                                        timer.Id, timer.Message, timer.StartedBy, timer.TimeLeft.ToMiniString());
                    }
                }
                return;
            }

            // Abort a timer
            if (param.Equals("abort", StringComparison.OrdinalIgnoreCase))
            {
                int timerId;
                if (cmd.NextInt(out timerId))
                {
                    ChatTimer timer = ChatTimer.FindTimerById(timerId);
                    if (timer == null || !timer.IsRunning)
                    {
                        player.Message("Given timer (#{0}) does not exist.", timerId);
                    }
                    else
                    {
                        timer.Stop();
                        string abortMsg = String.Format("&Y(Timer) {0}&Y aborted a timer with {1} left: {2}",
                                                         player.ClassyName, timer.TimeLeft.ToMiniString(), timer.Message);
                        Chat.SendSay(player, abortMsg);
                    }
                }
                else
                {
                    CdTimer.PrintUsage(player);
                }
                return;
            }

            // Start a timer
            if (player.Info.IsMuted)
            {
                player.MessageMuted();
                return;
            }
            if (player.DetectChatSpam()) return;
            TimeSpan duration;
            if (!param.TryParseMiniTimespan(out duration))
            {
                CdTimer.PrintUsage(player);
                return;
            }
            if (duration > DateTimeUtil.MaxTimeSpan)
            {
                player.MessageMaxTimeSpan();
                return;
            }
            if (duration < ChatTimer.MinDuration)
            {
                player.Message("Timer: Must be at least 1 second.");
                return;
            }

            string sayMessage;
            string message = cmd.NextAll();
            if (String.IsNullOrEmpty(message))
            {
                sayMessage = String.Format("&Y(Timer) {0}&Y started a {1} timer",
                                            player.ClassyName,
                                            duration.ToMiniString());
            }
            else
            {
                sayMessage = String.Format("&Y(Timer) {0}&Y started a {1} timer: {2}",
                                            player.ClassyName,
                                            duration.ToMiniString(),
                                            message);
            }
            Chat.SendSay(player, sayMessage);
            ChatTimer.Start(duration, message, player.Name);
        }

        #endregion

    }

}
