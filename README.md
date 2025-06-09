# F-16 VR Flight Training Simulator

An immersive, VR-compatible F-16 "Fighting Falcon" flight simulator developed in Unity with C#. This project provides an authentic aviation experience blending entertainment, education, and virtual reality technology.

---

## 🔗 Project Repository

This repository contains the full code and assets for the F-16 Training Simulator developed as part of the CPE Term Project at NYU Abu Dhabi.

> Developed by: Behruz Erkinov, Mohamed Benaich, Ahmed Abdelrahman, Paul Muhoro  
> Instructor: NYUAD Engineering  
> Academic Term: Spring 2024

---

## ✈️ Project Overview

The F-16 VR Flight Training Simulator allows users to:
- **Pilot a realistic F-16 fighter jet** with authentic flight dynamics.
- **Choose between multiple modes**: free-flight exploration or guided takeoff and landing tutorials.
- **Experience immersive VR gameplay** with Oculus support.
- **Operate a fully functional Heads-Up Display (HUD)** and Helmet Mounted Display (HMD) for enhanced realism.

This project aims to deliver a highly engaging and educational virtual training platform while making advanced flight simulation accessible to the general public.

---

## 🚀 Technologies Used

- **Unity Engine (C#)**
- **VR Integration (Oculus compatible)**
- **Advanced Aircraft Physics (Aerodynamic simulation via GasGiant Physics library)**
- **Custom Aircraft Controls & UI Systems**

---

## ⚙️ Key Features

### Flight Dynamics & Physics

- Real-time aerodynamic calculations using rigid-body physics.
- Control surfaces modeled: elevators, flaperons, and rudder.
- Forces simulated: lift, gravity, thrust, and drag.
- Flight physics based on academic research:
  > W. Khan and M. Nahon, "Real-time modeling of agile fixed-wing UAV aerodynamics," 2015 ICUAS.

- Physics engine reference: [GasGiant Aircraft Physics](https://github.com/gasgiant/Aircraft-Physics)

### Aircraft Controls

- Full control over pitch, roll, yaw, throttle, flaps, landing gears, airbrakes, and engine.
- Controller and keyboard support.
- Afterburner activation system.
- Realistic startup procedures (engine activation, brake release, flap control).

### Visuals & Environment

- High-fidelity F-16 3D model from Unity Asset Store: [Modern Fighter Jets Pack](https://assetstore.unity.com/packages/3d/vehicles/air/modern-fighter-jets-39460)
- Realistic terrain environment: runway, trees, skybox, green landscape.
- Dynamic camera system (First-Person, Third-Person, Profile views).
- Rudder and control surface visual feedback synced with controls.

### UI & HUD Systems

- Helmet Mounted Display (HMD) and HUD providing real-time aircraft data:
  - Airspeed, altitude, Mach number, engine status, throttle level, flaps, airbrake, brakes, landing gear.
- Canvas switching between VR Canvas and standard Main Canvas.
- Dynamic camera and display switching.

---

## 🏆 Educational Value

- Demonstrates advanced rigid-body flight physics in Unity.
- Implements real-time aerodynamic modeling using control surfaces.
- Integrates realistic visual and UI feedback for flight state.
- Full software pipeline: modeling → physics → control → VR → UI.

---

## 🎯 Future Improvements

- Expanded flight mission scenarios.
- Enhanced terrain and environmental features.
- Multiplayer or AI-based training opponents.
- More complex damage modeling and emergency situations.

---

## 📷 Screenshots / Demo

> (Optional: Insert some screenshots or videos showcasing flight scenes, cockpit view, VR mode, HUD, etc.)

---

## 📄 References

- GasGiant Aircraft Physics: https://github.com/gasgiant/Aircraft-Physics
- Lockheed Martin F-16 Aircraft Specs: info.publicintelligence.net/HAF-F16.pdf
- Khan, W., & Nahon, M. (2015). Real-time modeling of agile fixed-wing UAV aerodynamics. ICUAS 2015.

---

## 🔧 Setup Instructions

> (Optional: add instructions on how to run or build the project if you want it fully complete for public use)

---

## License

This project was developed for educational purposes as part of NYUAD's CPE Term Project.

---

