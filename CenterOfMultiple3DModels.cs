        foreach (MeshFilter data in GetComponentsInChildren<MeshFilter>())
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

                cachi = Vector3.ProjectOnPlane(cachi, transform.forward);

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

                cachi = Vector3.ProjectOnPlane(cachi, transform.forward);

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
                    colli2.z = cachi.z ;
                }
            }
        }

        Vector3 Final = (colli + colli2)/2 - Vector3.ProjectOnPlane(transform.position, transform.forward);
        Final = Quaternion.LookRotation(Vector3.up, Vector3.forward) * Final;
        Final.x *= DistanceScaleForCenterFind.x;
        Final.y *= DistanceScaleForCenterFind.y;
        Final.z *= DistanceScaleForCenterFind.z;
        
        // Final is the Center of your 3d Model Cluster
