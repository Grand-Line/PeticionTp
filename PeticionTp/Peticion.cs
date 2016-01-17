using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShockAPI;
using Newtonsoft.Json;
using TerrariaApi;
using TerrariaApi.Server;
using Terraria;
using System.Timers;

namespace PeticionTp
{
    [ApiVersion(1,22)]
    public class Peticion : TerrariaPlugin
    {
        public override string Author
        {
            get { return "GNR092"; }
        }
        public override string Description
        {
            get { return "Pide a un jugador para poder teleportarse."; }
        }
        public override string Name
        {
            get { return "PeticionTP"; }
        }
       public override Version Version
        {
            get { return  Assembly.GetExecutingAssembly().GetName().Version; }
        }
        #region declaracion
        private Timer Temporizador;
        private bool[] PermitirTP = new bool[256];
        private SolicitarTp[] SolicitarTps = new SolicitarTp[256];
        private Configuracion configuracion = new Configuracion();
        #endregion
        public Peticion(Main game) : base(game)
		{
            for (int i = 0; i < SolicitarTps.Length; i++)
                SolicitarTps[i] = new SolicitarTp();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.GameInitialize.Deregister(this, OnInitialize);
                ServerApi.Hooks.ServerLeave.Deregister(this, OnLeave);
                Temporizador.Dispose();
            }
        }
        public override void Initialize()
        {
            ServerApi.Hooks.GameInitialize.Register(this, OnInitialize);
            ServerApi.Hooks.ServerLeave.Register(this, OnLeave);
        }

        private void OnLeave(LeaveEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void OnInitialize(EventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
