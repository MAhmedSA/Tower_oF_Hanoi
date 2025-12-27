# Unity Tower of Hanoi

This project is a Unity implementation of the **Tower of Hanoi** puzzle.The project demonstrates clean architecture, modular code design, animation systems, and AI-based puzzle solving.

---

## Table of Contents

- [Overview](#overview)  
- [Features](#features)  
- [Architecture & Design](#architecture--design)  
- [Gameplay Implementation](#gameplay-implementation)  
  - [Disk Movement & Validation](#disk-movement--validation)  
  - [Undo/Redo System](#undoredo-system)  
  - [Auto-Solver](#auto-solver)  
  - [Visual Feedback & Animation](#visual-feedback--animation)  
- [Technical Decisions & Trade-offs](#technical-decisions--trade-offs)  
- [How to Run](#how-to-run)  
- [Future Improvements](#future-improvements)

---

## Overview

The Tower of Hanoi puzzle involves moving disks from a source tower to a target tower while obeying these rules:

1. Only one disk can be moved at a time.  
2. A larger disk cannot be placed on top of a smaller disk.  

This implementation supports both **manual input via mouse clicks** and an **automatic solver**. It also includes **undo/redo functionality**, visual feedback for valid/invalid moves, and configurable levels via the Inspector.

---

## Features

- Configurable number of disks and towers.  
- Mouse click input system with tower selection.  
- Valid/invalid move feedback (color flash for invalid moves).  
- Smooth disk animations using a `DiskMoveAnimationService`.  
- Undo/Redo functionality integrated with manual and AI moves.  
- Auto-solver using **recursion** to solve from any state.  
- Adjustable speed for automatic moves.  
- Reset/Restart game functionality.  
- Clean, modular code architecture supporting maintainability and scalability.  

---

## Architecture & Design

The project uses **modular, dependency-injected architecture**:

- **GameBootstrapper:** Initializes dependencies and injects services into input, UI, animation, and game manager.  
- **GameManager:** Responsible for generating towers/disks, handling game state, reset, and auto-solving logic.  
- **MoveService:** Handles all move requests, validates moves via `IMoveValidator`, and executes commands through `CommandInvoker`.  
- **CommandInvoker & MoveDiskCommand:** Implements the **Command Pattern** for undo/redo functionality.  
- **DiskMoveAnimationService:** Animates disks between towers with smooth lifting, moving, and placement.  
- **UIManager:** Handles buttons, move counter, and updates UI based on game state.  
- **HanoiSolver:** AI solver that recursively solves the puzzle. Uses a coroutine to animate moves step by step.  
- **FeedbackService:** Provides visual feedback by highlighting towers for selection, deselection, and invalid moves.  
- **PlayerInput & MouseClickInput:** Handles user input and tower selection logic.

This design separates **game logic**, **input**, **UI**, and **animations**, making it easy to extend or swap features.

---

## Gameplay Implementation

### Disk Movement & Validation

- `MoveService.TryMove(from, to)` checks if the move is valid using `HanoiMoveValidator`.  
- Invalid moves trigger visual feedback via `FeedbackService`.  
- After animation, `MoveService.ExecuteMove()` updates the game state using `CommandInvoker`.  

### Undo/Redo System

- Implemented via `CommandInvoker` with **stacks for undo and redo**.  
- Supports undo/redo for both **manual moves** and **auto-solver moves**.  
- UI buttons are dynamically enabled/disabled based on game state.

### Auto-Solver

- `HanoiSolver` uses a **recursive algorithm** (not BFS) for optimal moves.  
- Big O complexity: \(O(2^n - 1)\), which is optimal for Tower of Hanoi.  
- Works from any game state by resetting and solving recursively.  
- Integrated with disk animations and adjustable move delay.

### Visual Feedback & Animation

- Towers flash red on invalid moves.  
- Selected towers highlight yellow.  
- Disk movements are smooth: **lift → move → drop** sequence.  
- Animations are decoupled from game logic, enabling asynchronous execution without blocking gameplay.

---

## Technical Decisions & Trade-offs

- **Recursion vs BFS for Auto-Solver:** Recursion chosen for optimal time complexity and simplicity; BFS would be \(O(3^n)\), less efficient.  
- **Command Pattern for Undo/Redo:** Enables reliable reversal of moves without coupling to input logic.  
- **Dependency Injection via Bootstrapper:** Simplifies testing and modularity.  
- **Animation Decoupling:** Ensures moves are executed only after animations complete, avoiding race conditions.  

---

## How to Run

1. Open the project in **Unity 6000.0.59f2**.  
2. Configure `LevelData` ScriptableObject for the desired number of disks, towers, and materials.  
3. Play the scene:  
   - Click towers to move disks manually.  
   - Use **Undo / Redo / Reset / Auto-Solve** buttons in the UI.  
4. Observe animations and visual feedback.

---

## Future Improvements

- Add **sound effects** for moves, selection, and invalid moves.  
- Implement **drag-and-drop input** in addition to click input.  
- Add **save/load game state**.  
- Add **difficulty settings** affecting auto-solver speed or visual complexity.  
- Add **mobile touch support** and multi-platform optimization.  

---

## Conclusion

This project demonstrates strong Unity architecture, separation of concerns, clean coding, and problem-solving skills. The recursive auto-solver, animation system, and undo/redo functionality highlight both technical depth and attention to user experience.
