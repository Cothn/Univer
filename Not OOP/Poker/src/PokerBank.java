import java.io.Console;

import java.util.Scanner;
public class PokerBank {
    static int Start1 = 1000;
    static int Start2 = 1000;
    static int Player1 = 1000;
    static int Player2 = 1000;
    static int Player1Bet = 0;
    static int Player2Bet = 0;
    static int Bank = 0;
    static int Bet = 0;
    static int blind;

        public static void main(String[] args) {

            String command = "";
            Scanner scanner = new Scanner(System.in);

            while(!command.equals("End"))
            {
                Player1Bet = 0;
                Player2Bet = 0;
                Bank = 0;
                Bet = 10;
                blind = 1;
                while (((!command.equals("end")) && (Player1 != 0) && (Player2 != 0) ) || (blind != 5) ) {

                        System.out.println("Player1 Money: " + Player1 + " Player1Bet: " +Player1Bet +" Bet: "+Bet+" Bank: "+ Bank);
                        System.out.println("Player2 Money: " + Player2 + " Player2Bet: " +Player2Bet +" Bet: "+Bet+" Bank: "+ Bank);
                        System.out.println("Player1 Command(C-Check, B-Bet, F-Fold):");
                        command = scanner.nextLine();
                        CheckCommand(command, 1);

                        System.out.println("Player1 Money: " + Player1 + " Player1Bet: " +Player1Bet +" Bet: "+Bet+" Bank: "+ Bank);
                        System.out.println("Player2 Money: " + Player2 + " Player2Bet: " +Player2Bet +" Bet: "+Bet+" Bank: "+ Bank);
                        System.out.println("Player2 Command(C-Check, B-Bet, F-Fold):");
                        command = scanner.nextLine();
                        CheckCommand(command, 2);
                        if((Player1Bet == Player2Bet) && (Bank != 0))
                        {
                            blind++;
                            Player1Bet = 0;
                            Player2Bet = 0;
                            Bet = 10;
                            //System.out.println("End Match?(Y/N):");
                            //command = scanner.nextLine();
                            //if (command.equals("y")) {
                            if (blind == 5) {
                                blind = 1;
                                System.out.println("Set Win?(1/2):");
                                command = scanner.nextLine();
                                if (command.equals("1")) {
                                    Player1 += Bank;
                                }
                                else
                                {
                                    Player2 += Bank;
                                }
                                Bank = 0;
                            }
                        }

                }
                System.out.println("End?");
                command = scanner.nextLine();
                Player1 = Start1;
                Player2 = Start2;


            }


        }

        public static void Fold(int num) {

            if( num == 1) {
                Player2 += Bank;
            }
            else
            {
                Player1 += Bank;
            }
            Player1Bet = 0;
            Player2Bet = 0;
            Bet = 10;
            Bank = 0;
            blind = 1;
        }

    public static void Bet(int num) {
        System.out.println("Set Your Bet:");
        Scanner scanner = new Scanner(System.in);
        int newBet = scanner.nextInt();
        scanner.nextLine();
        if( num == 1) {
            if(((newBet + Player1Bet)  >= Bet) && (Player1 >= newBet)  ) {
                Player1Bet += newBet;
                Player1 -= newBet;
                Bank += newBet;
                Bet = Player1Bet;
            }
            else
            {
                Check(num);
            }

        }
        else
        {
            if(((newBet + Player2Bet)  >= Bet) && (Player2 >= newBet)  ) {
                Player2Bet += newBet;
                Player2 -= newBet;
                Bank += newBet;
                Bet = Player2Bet;
            }
            else
            {
                Check(num);
            }
        }
    }

    public static void Check(int num) {

        if( num == 1) {
            Player1 -=  Bet - Player1Bet;
            Bank += Bet - Player1Bet;
            Player1Bet = Bet;
            if (Player1 < 0)
            {
                Bank += Player1;
                Player1Bet += Player1;
                Player1 = 0;
            }
        }
        else
        {
            Player2 -=  Bet - Player2Bet;
            Bank += Bet - Player2Bet;
            Player2Bet = Bet;
            if (Player2 < 0)
            {
                Bank += Player2;
                Player2Bet += Player2;
                Player2 = 0;
            }
        }
    }

        public static void CheckCommand(String s, int num) {

            switch (s) {
                case "C": {
                    Check(num);
                    break;
                }
                case "B": {
                        Bet(num);
                    break;
                }
                case "F": {

                        Fold(num);

                    break;
                }

                default: {
                    System.out.println("Incorrect!");
                }
            }
        }

    }


