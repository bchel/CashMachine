using System;
using Xunit;
using Domain;
using Domain.Exceptions;

namespace Tests
{
    public class ATMTests
    {
        [Fact]
        public void Deliver30()
        {
            //Arrange
            var atm = new ATM();
            //Act
            var notes = atm.GetNotes(30);
            //Assert
            Assert.True(notes.Count == 2);
            Assert.Equal(20, notes[0], 0);
            Assert.Equal(10, notes[1], 0);
        }

        [Fact]
        public void Deliver80()
        {
            //Arrange
            var atm = new ATM();
            //Act
            var notes = atm.GetNotes(80);
            //Assert
            Assert.True(notes.Count == 3);
            Assert.Equal(50, notes[0], 0);
            Assert.Equal(20, notes[1], 0);
            Assert.Equal(10, notes[2], 0);
        }

        [Fact]
        public void Deliver125ThrowsException()
        {
            //Arrange
            var atm = new ATM();
            //Act
            //Assert
            Assert.Throws<NoteUnavailableException>(()=>atm.GetNotes(125));
        }

        [Fact]
        public void DeliverMinus130ThrowsException()
        {
            //Arrange
            var atm = new ATM();
            //Act
            //Assert
            Assert.Throws<InvalidArgumentException>(() => atm.GetNotes(-130));
        }

        [Fact]
        public void DeliverNull()
        {
            //Arrange
            var atm = new ATM();
            //Act
            var notes = atm.GetNotes(null);
            //Assert
            Assert.True(notes.Count == 0);
        }

        [Fact]
        public void Deliver1390()
        {
            //Arrange
            var atm = new ATM();
            //Act
            var notes = atm.GetNotes(1390);
            //Assert
            Assert.True(notes.Count == 16);
            Assert.Equal(20, notes[15]);
            Assert.Equal(20, notes[14]);
            Assert.Equal(50, notes[13]);
            Assert.Equal(100, notes[12]);
        }
    }
}
