using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Cinema
{
    public static class Program
    {
        private const int FIRST_SEAT_INDEX = 0;

        private static string[] people;
        private static bool[] reservedSeats;
        private static bool areChanged = true;

        static void Main()
        {
            people = Console.ReadLine().Split(", ");
            reservedSeats = new bool[people.Length];

            MarkReservedSeats();
            GenerateSeatsVariations(0);
        }

        private static void GenerateSeatsVariations(int seatIndex)
        {
            int peopleCount = people.Length;
            int nextSeatIndex = seatIndex + 1;

            if (nextSeatIndex >= peopleCount)
            {
                if ( areChanged)
                {
                    Console.WriteLine(string.Join(' ', people));
                }
                return;
            }

            if (reservedSeats[seatIndex])
            {
                GenerateSeatsVariations(nextSeatIndex);
                return;
            }

            GenerateSeatsVariations(nextSeatIndex);

            for (int nextIndex = nextSeatIndex; nextIndex < peopleCount; nextIndex++)
            {
                areChanged = TryChangePeopleSeats(seatIndex, nextIndex);
                GenerateSeatsVariations(nextSeatIndex);

                if (areChanged)
                {
                    TryChangePeopleSeats(seatIndex, nextIndex);
                }

                areChanged = false;
            }
        }

        private static bool TryChangePeopleSeats(int firstSeat, int secondSeat)
        {
            if (firstSeat == secondSeat || reservedSeats[firstSeat] || reservedSeats[secondSeat])
            {
                return false;
            }

            string temporaryPersonSeat = people[secondSeat];
            people[secondSeat] = people[firstSeat];
            people[firstSeat] = temporaryPersonSeat;

            return true;
        }

        private static void MarkReservedSeats()
        {
            string input;

            while ((input = Console.ReadLine()) != "generate")
            {
                string[] reservation = input.Split(" - ");
                string name = reservation[0];
                int seatNumber = int.Parse(reservation[1]);
                int seatIndex = seatNumber - 1;

                reservedSeats[seatIndex] = true;
                int currentSeat = Array.IndexOf(people, name);
                if (currentSeat != seatIndex)
                {
                    people[currentSeat] = people[seatIndex];
                    people[seatIndex] = name;
                }
            }
        }
    }
}
