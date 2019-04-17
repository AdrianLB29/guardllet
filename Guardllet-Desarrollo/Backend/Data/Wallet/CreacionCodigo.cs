using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using ZXing;


namespace Guardllet_Desarrollo.Backend.Data.Wallet
{
    public class CreacionCodigo
    {
        public static string Monedero(string data) 
        {
            string codigo = "IPN000" + data + "00000";

            return codigo;
        }

        public static Byte[] Barras(string codigo) 
        {
            BarcodeWriter data = new BarcodeWriter();

            data.Format = BarcodeFormat.CODE_128;

            Bitmap img = new Bitmap(data.Write(codigo), 300, 200);

            Image img_codigo = (Image)img;

            ImageConverter converter = new ImageConverter();
            Byte[] bytes_image = (byte[])converter.ConvertTo(img_codigo, typeof(byte[]));


            return bytes_image;
        }
    }
}