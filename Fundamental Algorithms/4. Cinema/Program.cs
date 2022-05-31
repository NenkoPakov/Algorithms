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

            ICollection<int> nonReservedSeatIndexes = new List<int>();
            for (int i = 0; i < reservedSeats.Length; i++)
            {
                if (!reservedSeats[i])
                {
                    nonReservedSeatIndexes.Add(i);
                }
            }

            PermuteNonReservedSeats(nonReservedSeatIndexes.ToArray(), 0);
        }

        private static void PermuteNonReservedSeats(int[] nonReservedSeatIndexes, int seatIndex)
        {
            int seatsCount = nonReservedSeatIndexes.Length;
            int nextSeatIndex = seatIndex + 1;

            if (nextSeatIndex >= seatsCount)
            {
                Console.WriteLine(string.Join(' ', people));
                return;
            }

            PermuteNonReservedSeats(nonReservedSeatIndexes, seatIndex + 1);

            for (int nextIndex = nextSeatIndex; nextIndex < seatsCount; nextIndex++)
            {

                SwapSeats(nonReservedSeatIndexes[seatIndex], nonReservedSeatIndexes[nextIndex]);
                PermuteNonReservedSeats(nonReservedSeatIndexes, seatIndex + 1);
                SwapSeats(nonReservedSeatIndexes[seatIndex], nonReservedSeatIndexes[nextIndex]);
            }
        }

        private static void SwapSeats(int firstSeat, int secondSeat)
        {
            string temporaryPersonSeat = people[secondSeat];
            people[secondSeat] = people[firstSeat];
            people[firstSeat] = temporaryPersonSeat;
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
