using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridComponent {
    void Initialize();
    void Update();
    void Animate();
    void Destroy();
}
