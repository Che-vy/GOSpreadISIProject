using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager
{
    /// <summary>
    /// Play/Stop the Particle system of an object
    /// </summary>
    /// <param name="element"> Game object with the particle system you want to Play/Stop </param>
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
