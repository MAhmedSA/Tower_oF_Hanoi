# 🧩 Tower of Hanoi

A Unity-based implementation of the **Tower of Hanoi** puzzle featuring
manual gameplay, undo/redo support, and an **AI auto-solver** designed
with clean architecture principles.

---

## 🚀 Features

- **Manual Disk Movement** with rule validation
- **Undo / Redo System** using Command Pattern
- **Move Counter** with single source of truth
- **AI Auto-Solve** with adjustable speed
- **Reset Game** without destroying objects
- **Solve From Any State**
- Clean and scalable architecture

---

## 🧠 AI Solver Design

### Why Recursion Instead of BFS

The AI solver uses a **recursive algorithm**, which is the optimal solution
for the Tower of Hanoi problem.

| Algorithm | Time Complexity |
|---------|----------------|
| BFS | **O(3ⁿ)** |
| Recursive Hanoi | **O(2ⁿ − 1)** |

- BFS explores all possible states → memory heavy
- Recursive solution guarantees **minimum moves**
- Deterministic and efficient

---

## 🔄 Solving From Any State

The solver assumes a clean initial state.
To support solving from **any intermediate configuration**:

- The game **undoes all moves** using command history
- Command history is cleared
- Solver runs from a valid base state

This avoids destroying or recreating game objects.

---

## 🧱 Project Structure

### Core Systems

`GameManager.cs`
- Controls game flow (start, reset, auto-solve)

`MoveService.cs`
- Handles validated moves
- Delegates undo/redo

`CommandInvoker.cs`
- Stores move history
- Handles undo / redo
- Provides move count

`HanoiSolver.cs`
- Recursive AI solver
- Implements `ISolver`

`UIManager.cs`
- Manages UI buttons and move counter
- Decoupled via interfaces

`GameBootstrapper.cs`
- Wires dependencies
- Handles dependency injection

---

## 🧠 Architecture Overview

- **Command Pattern** for undo/redo/reset
- **Dependency Injection** via bootstrapper
- **Interface-based design** for loose coupling
- **Single Responsibility Principle**

---

## 🧪 Reset Strategy

Instead of regenerating the level:

- Undo all executed commands
- Clear command history
- Maintain object references

This ensures a clean and fast reset.

---

## 📌 Summary

This project demonstrates:

- Algorithmic decision-making
- Clean Unity architecture
- AI integration with gameplay
- Professional undo/redo systems
- Scalable UI-to-logic separation
