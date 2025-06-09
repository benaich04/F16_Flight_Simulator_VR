# F-16 VR Flight Training Simulator

This project implements a high-fidelity F-16 "Fighting Falcon" flight simulator with full VR integration, realistic aerodynamic modeling, and custom rigid-body physics. Developed fully in Unity (C#), the simulator models real-time aircraft behavior using accurate control surface dynamics, custom physics engines, and advanced UI/HUD systems.

---

## Project Summary

The simulator reproduces key flight dynamics of the General Dynamics F-16 aircraft, including pitch, roll, yaw, aerodynamic forces, engine thrust modeling, and full 3D visualization. The simulation includes:

- Physics-based rigid-body aerodynamics.
- Controller and VR headset integration.
- Full instrumentation (HUD, HMD, and dynamic cockpit readouts).
- First-person and third-person camera systems.
- Custom aerodynamic models derived from academic research.

---

## Technical Stack

- Unity Game Engine (C#)
- Oculus VR SDK
- Unity Canvas UI System
- GasGiant Aircraft Physics (Adapted & Extended)
- Custom Aerodynamic Model
- Real-Time Rigidbody Physics

---

## Aerodynamic Model

The simulation applies real-time force calculations for each control surface (flaperons, elevators, rudder) using parameterized aerodynamic equations:

```csharp
public enum ControlInputType { Pitch, Yaw, Roll, Flap }

public class AeroSurface : MonoBehaviour
{
    [SerializeField] AeroSurfaceConfig config = null;
    public bool IsControlSurface;
    public ControlInputType InputType;
    public float InputMultiplyer = 1;
    private float flapAngle;

    public void SetFlapAngle(float angle)
    {
        flapAngle = Mathf.Clamp(angle, -Mathf.Deg2Rad * 50, Mathf.Deg2Rad * 50);
    }

    public BiVector3 CalculateForces(Vector3 worldAirVelocity, float airDensity, Vector3 relativePosition)
    {
        // Computes lift, drag, and torque forces based on AoA, stall behavior, lift slope, and surface config.
    }
}
