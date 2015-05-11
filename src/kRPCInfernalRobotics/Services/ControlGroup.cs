using System.Collections.Generic;
using System.Linq;
using KRPC.Service.Attributes;
using KRPC.Utils;

namespace KRPCInfernalRobotics.Services
{
    [KRPCClass (Service = "InfernalRobotics")]
    public sealed class ControlGroup : Equatable<ControlGroup>
    {
        readonly IRWrapper.IControlGroup controlGroup;

        internal ControlGroup (IRWrapper.IControlGroup controlGroup)
        {
            this.controlGroup = controlGroup;
        }

        public override bool Equals (ControlGroup obj)
        {
            return controlGroup == obj.controlGroup;
        }

        public override int GetHashCode ()
        {
            return controlGroup.GetHashCode ();
        }

        [KRPCProperty]
        public string Name { get { return controlGroup.Name; } }

        [KRPCProperty]
        public string ForwardKey { get { return controlGroup.ReverseKey; } }

        [KRPCProperty]
        public string ReverseKey { get { return controlGroup.ForwardKey; } }

        [KRPCProperty]
        public float Speed { get { return controlGroup.Speed; } }

        [KRPCProperty]
        public bool Expanded { get { return controlGroup.Expanded; } }

        [KRPCProperty]
        public IList<Servo> Servos {
            get { return controlGroup.Servos.Select (x => new Servo (x)).ToList (); }
        }

        [KRPCMethod]
        public void MoveRight ()
        {
            controlGroup.MoveRight ();
        }

        [KRPCMethod]
        public void MoveLeft ()
        {
            controlGroup.MoveLeft ();
        }

        [KRPCMethod]
        public void MoveCenter ()
        {
            controlGroup.MoveCenter ();
        }

        [KRPCMethod]
        public void MoveNextPreset ()
        {
            controlGroup.MoveNextPreset ();
        }

        [KRPCMethod]
        public void MovePrevPreset ()
        {
            controlGroup.MovePrevPreset ();
        }

        [KRPCMethod]
        public void Stop ()
        {
            controlGroup.Stop ();
        }
    }
}
