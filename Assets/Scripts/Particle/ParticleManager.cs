using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleManager
{
    /// <summary>
    /// Activate/deactivate the Particle system of an object
    /// </summary>
    /// <param name="element"> Game object with the particle system you want to activate/deactivate </param>
    public static void PlayParticleSystem(GameObject element)
    {
        if (element.GetComponent<ParticleSystem>())
            element.GetComponent<ParticleSystem>().Play();
    }

    public static void StopParticleSystem(GameObject element)
    {
        if (element.GetComponent<ParticleSystem>())
            element.GetComponent<ParticleSystem>().Stop();
    }
}
