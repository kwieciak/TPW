﻿using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model
{
    /* 
     * Circle podobnie jak Ball musi informowac warstwe wyzsza o zmianie jego atrybutow
     * Dziala to dokladnie tak samo jak wlasnie w Ballu, wiec patrz tam.
     * Roznica jest tylko taka, ze ViewModel korzysta z ObservableCollection<Circle>,
     * ktora jakby nasluchuje zmian (czyli RaisePropertyChanged()) dla calej Kolekcji.
     * I potem View nasluchuje zmian w tej kolekcji.
     */
    internal class Circle : ICircle, INotifyPropertyChanged
    {
        public override int x { get => _x; }
        public override int y { get => _y; }

        public override int radius { get => _radius; }

        private int _x;
        private int _y;
        private int _radius;

        public Circle(int x, int y, int radius)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        /* Jak juz wyzej pisalem, jest to dosyc problematyczna metoda.
         * Jest to wywolywane gdy Ball sie zmieni (czyli w gruncie rzeczy zmieni sie jego X badz Y)
         * 
         * 
         * Keep in mind:
         *      Problem pojawia sie gdy:
         *          - PosX nie ma okreslonego gettera 
         *          - PosX nie ma okreslonego settera 
         *      Badz po prostu nie ma do tych rzeczy dostepu.
         *      IDE z jakiegos powodu nie wypluwa bledu w takiej sytuacji
         *      i powoduje to crash procesu (odwolujemy sie do pamieci do ktorej nie mamy dostepu)
         */
        public override void UpdateCircle(Object s, LogicEventArgs e)
        {
            IBall ball = (IBall)s;
            _x = (int)ball.Position.X;
            RaisePropertyChanged("x");
            _y = (int)ball.Position.Y;
            RaisePropertyChanged("y");
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }



}
