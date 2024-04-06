using OpenTK.Mathematics;
using System;

using OpenTK.Graphics.OpenGL4;

namespace tarea1
{
 
    public class Televisor
    {
        private float[] vertices = {
            -0.15f, -0.20f, 0f,  // Primer punto (base)
            0.15f, -0.20f, 0f,
           -0.15f, -0.20f, -0.3f,  
            0.15f, -0.20f, -0.3f,

            -0.17f, 0.10f, -0.10f,  // Primer punto (cuerpo)//4
            0.17f, 0.10f, -0.10f,
           -0.17f, -0.10f, -0.10f, 
            0.17f, -0.10f, -0.10f,

            -0.17f, 0.10f, -0.25f,  // Primer punto (cuerpo detras) //8
            0.17f, 0.10f, -0.25f,
           -0.17f, -0.10f, -0.25f,
            0.17f, -0.10f, -0.25f,

            -0.02f, -0.20f, -0.10f,  // Primer punto (tronco)//12
            0.02f, -0.20f, -0.10f,
            -0.02f, -0.20f, -0.25f,  
            0.02f, -0.20f, -0.25f,

           -0.02f, -0.10f, -0.10f,  // Primer punto (tronco arriba)//16
            0.02f, -0.10f, -0.10f,
           -0.02f, -0.10f, -0.25f,
            0.02f, -0.10f, -0.25f,


        };

        Shader shader;
        private Vector3 origen;

        public Televisor(Shader shader, Vector3 origen)
        {
            this.shader = shader;
            this.origen = origen;
        }

        void dibujarBase()
        {
            uint[] index = { 0, 1, 2, 3 , 0, 2, 1, 3};
            shader.SetVector3("objectColor", new Vector3(0.0f, 0.0f, 0.0f));
            GL.BufferData(BufferTarget.ElementArrayBuffer, index.Length * sizeof(uint), index, BufferUsageHint.StaticDraw);
            //GL.DrawElements(PrimitiveType.Triangles, index.Length, DrawElementsType.UnsignedInt, 0);
            // Dibuja las líneas utilizando el modo GL_LINES
            GL.DrawElements(PrimitiveType.Lines, index.Length, DrawElementsType.UnsignedInt, 0);
        }

        void dibujarBaseTV()
        {                   //delante                  //detras                    //union
            uint[] index = { 4, 5, 6, 7 , 4, 6, 5, 7 , 8, 9, 10, 11, 8, 10, 9, 11 , 4, 8 , 5, 9, 6, 10, 7, 11 };
            shader.SetVector3("objectColor", new Vector3(0.0f, 0.0f, 0.0f));
            GL.BufferData(BufferTarget.ElementArrayBuffer, index.Length * sizeof(uint), index, BufferUsageHint.StaticDraw);
            //GL.DrawElements(PrimitiveType.Triangles, index.Length, DrawElementsType.UnsignedInt, 0);
            // Dibuja las líneas utilizando el modo GL_LINES
            GL.DrawElements(PrimitiveType.Lines, index.Length, DrawElementsType.UnsignedInt, 0);
        }

        void dibujarTronco()
        {                   //abajo                           // arriba                         // union 
            uint[] index = { 12, 13 , 14, 15, 12, 14, 13, 15,  16, 17, 18, 19, 16, 18, 17, 19, 12, 16, 13, 17, 14, 18 , 15, 19  };
            shader.SetVector3("objectColor", new Vector3(0.0f, 0.0f, 0.0f));
            GL.BufferData(BufferTarget.ElementArrayBuffer, index.Length * sizeof(uint), index, BufferUsageHint.StaticDraw);
            //GL.DrawElements(PrimitiveType.Triangles, index.Length, DrawElementsType.UnsignedInt, 0);
            // Dibuja las líneas utilizando el modo GL_LINES
            GL.DrawElements(PrimitiveType.Lines, index.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void dibujar()
        {
            shader.Use();

           

            var move = Matrix4.Identity;
            move = move * Matrix4.CreateTranslation(origen.X, origen.Y, origen.Z);

            shader.SetMatrix4("origen", move);

            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            dibujarBase();
            dibujarBaseTV();
            dibujarTronco();
        }



    }
}
