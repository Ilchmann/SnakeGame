using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZakladniCtverecek
{
    class Ctverecek
    {
        public int Velikost { get; private set; }
        public int Rychlost { get; private set; }

        public Color Barva { get; private set; }

        public Vector2 Pozice;

        private Texture2D textura;

        public Keys SmerNahoru { get; private set; }
        public Keys SmerDolu { get; private set; }
        public Keys SmerDoleva { get; private set; }
        public Keys SmerDoprava { get; private set; }
        public Keys Ghost { get; private set; }
        

        public Ctverecek(int velikost, int rychlost, Color barva, float poziceX, float poziceY, GraphicsDevice zobrazovaciZarizeni, Keys nahoru, Keys dolu, Keys doleva, Keys doprava, Keys ghost, bool fake)
        {
            Velikost = velikost;
            Rychlost = rychlost;

            Barva = barva;

            Pozice.X = poziceX;
            Pozice.Y = poziceY;

            #region Priprava textury
            textura = new Texture2D(zobrazovaciZarizeni, Velikost, Velikost);

            Color[] barevnaData = new Color[Velikost * Velikost];

            for (int i = 0; i < barevnaData.Length; i++)
                barevnaData[i] = Color.White;

            textura.SetData(barevnaData);
            #endregion

            SmerDoleva = doleva;
            SmerDoprava = doprava;
            SmerNahoru = nahoru;
            SmerDolu = dolu;
            Ghost = ghost;
        }

        public void aktualizovat(bool fake, float poziceX, float poziceY)
        {
            if (Keyboard.GetState().IsKeyDown(SmerNahoru))
                Pozice.Y -= Rychlost;
            if (Keyboard.GetState().IsKeyDown(SmerDolu))
                Pozice.Y += Rychlost;
            if (Keyboard.GetState().IsKeyDown(SmerDoleva)) 
                Pozice.X -= Rychlost;
            if (Keyboard.GetState().IsKeyDown(SmerDoprava))
                Pozice.X += Rychlost;
            if (Keyboard.GetState().IsKeyDown(Ghost))
                Barva = Color.WhiteSmoke;
            if (Keyboard.GetState().IsKeyUp(Ghost))
                Barva = Color.Black;

            if (Barva == Color.Black && Pozice.Y < 0)
                Pozice.Y = 0;
            if (Barva == Color.Black && Pozice.X < 0)
                Pozice.X = 0;
            if (Barva == Color.Black && Pozice.Y > 600 - Velikost)
                Pozice.Y = 600 - Velikost;
            if (Barva == Color.Black && Pozice.X > 800 - Velikost)
                Pozice.X = 800 - Velikost;

        }

        public void vykreslit(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, Pozice, Barva);
        }
    }
}
