using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zinnia.Action;

namespace JorgeJGnz {

    public enum Axis
    {
        None,
        X,
        Y,
        Z
    }

    public class FloatEvent : UnityEvent<float>
    {

    }

    public class CentroidConstraint : FloatAction
    {
        [Header("Place this")]
        public Transform receiver;

        [Header("Between this")]
        public Transform A;
        public Transform B;

        [Header("Rotation")]
        public Transform lookAt;
        public Axis axisRelationX;
        public Axis axisRelationY;
        public Axis axisRelationZ;
        public Vector3 rotationOffset;

        [Header("Events")]
        public FloatEvent onNewDistance = new FloatEvent();

        [Header("Debugging")]
        public float currentDistance;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            receiver.transform.position = (A.position + B.position) / 2.0f;
            if (lookAt != null) receiver.LookAt(lookAt);

            Vector3 receiverAngles = receiver.eulerAngles;
            Quaternion meanRotation = Quaternion.Lerp(A.rotation, B.rotation, 0.5f);

            ApplyRotRelations(receiverAngles,meanRotation);

            receiverAngles += rotationOffset;

            receiver.eulerAngles = receiverAngles;

            currentDistance = Vector3.Distance(A.position, B.position);
            onNewDistance.Invoke(currentDistance);

            Receive(currentDistance);
        }

        void ApplyRotRelations(Vector3 receiverAngles, Quaternion meanRotation)
        {
            switch (axisRelationX)
            {
                case Axis.X:
                    receiverAngles.x = meanRotation.eulerAngles.x;
                    break;
                case Axis.Y:
                    receiverAngles.x = meanRotation.eulerAngles.y;
                    break;
                case Axis.Z:
                    receiverAngles.x = meanRotation.eulerAngles.z;
                    break;
            }

            switch (axisRelationY)
            {
                case Axis.X:
                    receiverAngles.y = meanRotation.eulerAngles.x;
                    break;
                case Axis.Y:
                    receiverAngles.y = meanRotation.eulerAngles.y;
                    break;
                case Axis.Z:
                    receiverAngles.y = meanRotation.eulerAngles.z;
                    break;
            }

            switch (axisRelationZ)
            {
                case Axis.X:
                    receiverAngles.z = meanRotation.eulerAngles.x;
                    break;
                case Axis.Y:
                    receiverAngles.z = meanRotation.eulerAngles.y;
                    break;
                case Axis.Z:
                    receiverAngles.z = meanRotation.eulerAngles.z;
                    break;
            }
        }

    }
}