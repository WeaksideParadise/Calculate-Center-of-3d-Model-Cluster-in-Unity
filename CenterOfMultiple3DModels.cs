
    public static Vector3 GetRelativeOffsetOfModelCluster(Transform Parent)
    {
        Vector3 colli = Vector3.ProjectOnPlane(Parent.position, Parent.forward);
        Vector3 colli2 = Vector3.ProjectOnPlane(Parent.position, Parent.forward);

        foreach (MeshFilter data in Parent.GetComponentsInChildren<MeshFilter>())
        {
            if (data != null)
            {
                Vector3 cachi = data.sharedMesh.bounds.max;

                cachi.x = cachi.x * data.transform.localScale.x;
                cachi.y = cachi.y * data.transform.localScale.y;
                cachi.z = cachi.z * data.transform.localScale.z;
                cachi = Quaternion.LookRotation(data.transform.forward, data.transform.up) * cachi;
                cachi.x += data.transform.position.x;
                cachi.y += data.transform.position.y;
                cachi.z += data.transform.position.z;

                cachi = Vector3.ProjectOnPlane(cachi, Parent.forward);

                if (cachi.x > colli.x)
                {
                    colli.x = cachi.x;
                }
                if (cachi.y > colli.y)
                {
                    colli.y = cachi.y;
                }
                if (cachi.z > colli.z)
                {
                    colli.z = cachi.z;
                }

                if (cachi.x < colli2.x)
                {
                    colli2.x = cachi.x;
                }
                if (cachi.y < colli2.y)
                {
                    colli2.y = cachi.y;
                }
                if (cachi.z < colli2.z)
                {
                    colli2.z = cachi.z;
                }

                cachi = data.sharedMesh.bounds.min;

                cachi.x = cachi.x * data.transform.localScale.x;
                cachi.y = cachi.y * data.transform.localScale.y;
                cachi.z = cachi.z * data.transform.localScale.z;
                cachi = Quaternion.LookRotation(data.transform.forward, data.transform.up) * cachi;
                cachi.x += data.transform.position.x;
                cachi.y += data.transform.position.y;
                cachi.z += data.transform.position.z;

                cachi = Vector3.ProjectOnPlane(cachi, Parent.forward);

                if (cachi.x > colli.x)
                {
                    colli.x = cachi.x;
                }
                if (cachi.y > colli.y)
                {
                    colli.y = cachi.y;
                }
                if (cachi.z > colli.z)
                {
                    colli.z = cachi.z;
                }

                if (cachi.x < colli2.x)
                {
                    colli2.x = cachi.x;
                }
                if (cachi.y < colli2.y)
                {
                    colli2.y = cachi.y;
                }
                if (cachi.z < colli2.z)
                {
                    colli2.z = cachi.z;
                }
            }
        }

        Vector3 Final = (colli + colli2) / 2 - Vector3.ProjectOnPlane(Parent.position, Parent.forward);
        Final = Quaternion.LookRotation(Vector3.up, Vector3.forward) * Final;
        Final.x *= 1/Parent.lossyScale.x;
        Final.y *= 1 / Parent.lossyScale.y;
        Final.z *= 1 / Parent.lossyScale.z;
        return Final;
    }
