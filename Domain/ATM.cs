using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;

namespace Domain
{
    public class ATM : IATM
    {
        private readonly List<decimal> availableNotes;

        public ATM()
        {
            availableNotes = new List<decimal> { 100, 50, 20, 10 };
        }

        public List<decimal> GetNotes(decimal? amount)
        {
            if (amount == null)
            {
                return new List<decimal>();
            }

            if (amount < 0)
            {
                throw new InvalidArgumentException();
            }

            if (!IsDividableBySmallestAvailableNote(amount))
            {
                throw new NoteUnavailableException();
            }

            var result = new List<decimal>();

            foreach (var note in availableNotes.OrderByDescending(x => x))
            {
                var notesCount = (int)(amount / note);
                if (notesCount == 0)
                {
                    continue;
                }
                result.AddRange(Enumerable.Repeat(note, notesCount));
                amount %= note;
                if (amount == 0)
                {
                    return result;
                }

            }

            return result;
        }

        private bool IsDividableBySmallestAvailableNote(decimal? amount)
        {
            return amount % availableNotes.Min() == 0;
        }
    }
}
