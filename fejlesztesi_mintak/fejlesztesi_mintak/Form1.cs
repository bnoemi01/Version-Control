﻿using fejlesztesi_mintak.Abstarctions;
using fejlesztesi_mintak.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fejlesztesi_mintak
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();

        private Toy _nextToy;

        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = toy.Width;
            mainPanel.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }

        private void buttonCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void buttonBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }
    }
}
