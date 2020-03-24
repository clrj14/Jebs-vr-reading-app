using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zinnia.Action;

namespace JorgeJGnz {

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
            receiverAngles.z = meanRotation.eulerAngles.x;
            receiver.eulerAngles = receiverAngles;

            currentDistance = Vector3.Distance(A.position, B.position);
            onNewDistance.Invoke(currentDistance);

            Receive(currentDistance);
        }

    }
}