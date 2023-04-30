namespace WeaksideParadise{
    public class RealWorldBounds{
        public static MyBounds GetBoundsOfChildren(GameObject Parent)
            {
                MyBounds final = new MyBounds();
                Matrix4x4 localToWorld = Parent.transform.localToWorldMatrix;
                MeshFilter[] meshes = Parent.GetComponentsInChildren<MeshFilter>();
                Vector3 RT = localToWorld.MultiplyPoint3x4(meshes[0].sharedMesh.vertices[0]), LB = localToWorld.MultiplyPoint3x4(meshes[0].sharedMesh.vertices[0]);

                foreach (MeshFilter mf in meshes)
                {
                    for (int i = 0; i < mf.sharedMesh.vertices.Length; ++i)
                    {
                        Vector3 world_v = localToWorld.MultiplyPoint3x4(mf.mesh.vertices[i]);
                        RT = GetMaxVector(RT, world_v);
                        LB = GetMinVector(LB, world_v);
                    }
                }
                final.RT = RT;
                final.LB = LB;
                final.Center = (RT + LB) / 2;
                final.Size = (Mathf.Abs((RT - LB).magnitude));
                return final;
            }
            [System.Serializable]
            public class MyBounds
            {
                public Vector3 RT = Vector3.zero, LB = Vector3.zero, Center = Vector3.zero;
                public float Size;
            }
            public static Vector3 GetMaxVector(Vector3 one, Vector3 two)
            {
                Vector3 final = new Vector3(one.x, one.y, one.z);
                if (two.x > final.x)
                {
                    final.x = two.x;
                }
                if (two.y > final.y)
                {
                    final.y = two.y;
                }
                if (two.z > final.z)
                {
                    final.z = two.z;
                }
                return final;
            }
            public static Vector3 GetMinVector(Vector3 one, Vector3 two)
            {
                Vector3 final = new Vector3(one.x, one.y, one.z);
                if (two.x < final.x)
                {
                    final.x = two.x;
                }
                if (two.y < final.y)
                {
                    final.y = two.y;
                }
                if (two.z < final.z)
                {
                    final.z = two.z;
                }
                return final;
            }
        }
    }
}
