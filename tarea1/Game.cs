using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace tarea1
{
    public class Game : GameWindow
    {
        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) { }

        Shader shader;

        private int vertexBufferObject;
        private int vertexArrayObject;
        private int elementBufferObject;

        private Matrix4 projection;
        private Matrix4 view;
        private Matrix4 model;

        Televisor televisor;
        Televisor televisor2;
        Televisor televisor3;
        Televisor televisor4;
        Televisor televisor5;
        Televisor televisor6;
        Televisor televisor7;
        Televisor televisor8;
        Televisor televisor9;




        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);

            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);

            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

         
           projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(30.0f), Size.X / (float)Size.Y, 0.1f, 70.0f);
         
            view = Matrix4.CreateTranslation(0.0f, 0.0f, -2.5f);
          // projection = Matrix4.CreateOrthographic(2.0f, 2.0f, 0.1f, 100.0f); // Tamaño de la proyección ortogonal en el plano XY
            model = Matrix4.Identity * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(20.0f));


            shader.SetMatrix4("model", model);
            shader.SetMatrix4("projection", projection);
            shader.SetMatrix4("view", view);

            televisor = new Televisor(shader, new Vector3(0.0f, 0.0f, 0.0f));

            televisor2 = new Televisor(shader, new Vector3(0.5f, 0.0f, 0.0f));

            televisor3 = new Televisor(shader, new Vector3(1.0f, 0.0f, 0.0f));

            televisor4 = new Televisor(shader, new Vector3(-0.7f, -0.3f, 0.0f));

            televisor5 = new Televisor(shader, new Vector3(-0.3f, -0.7f, 0.0f));


            televisor6 = new Televisor(shader, new Vector3(0.0f, 0.5f, 0.0f));

            televisor7 = new Televisor(shader, new Vector3(0.5f, 0.5f, 0.0f));

            televisor8 = new Televisor(shader, new Vector3(-0.5f, -0.1f, 0.0f));

            televisor9 = new Televisor(shader, new Vector3(-1.0f, 0.6f, 0.0f));





        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.BindVertexArray(vertexArrayObject);
            shader.Use();

           televisor.dibujar();
            televisor2.dibujar();
            televisor3.dibujar();
            televisor4.dibujar();
            televisor5.dibujar();
            televisor6.dibujar();
            televisor7.dibujar();
            televisor8.dibujar();
            televisor9.dibujar();

            Context.SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
        }

    }
}
