🧩 Tower of Hanoi – Unity (AI Solver & Undo-Based Reset)

This project is a Unity implementation of the Tower of Hanoi puzzle with both player interaction and an AI auto-solver.
The system is designed using clean architecture principles, command pattern, and dependency injection to ensure scalability, testability, and maintainability.

🎮 Features

Manual disk movement with rule validation

Undo / Redo functionality using Command Pattern

Move counter (single source of truth)

AI auto-solver with adjustable speed

Reset game without destroying objects

Solve puzzle from any intermediate state

Clean separation between UI, game logic, and services

🤖 AI Solver Design
Why Recursion (Not BFS)

The Tower of Hanoi problem is a classic recursive problem with a well-known optimal solution.

I intentionally implemented the AI solver using a recursive algorithm instead of Breadth-First Search (BFS).

Complexity Comparison
Approach	Time Complexity	Notes
BFS	O(3ⁿ)	Explores all possible states, memory heavy
Recursive Hanoi Algorithm	O(2ⁿ − 1)	Optimal and deterministic

BFS quickly becomes impractical as the number of disks increases.

The recursive solution guarantees the minimum number of moves.

No need to store or explore unnecessary states.

Solver Implementation

The solver follows the classic recursive steps:

Move n-1 disks to the auxiliary tower

Move the largest disk to the target tower

Move n-1 disks from auxiliary to target

This logic is implemented in HanoiSolver using an ISolver interface, allowing future solver strategies to be added without changing game logic.

🔄 Solving From Any State
Problem

The recursive Hanoi algorithm assumes a clean initial state (all disks on the first tower).
However, players can:

Make manual moves

Undo / redo moves

Leave the game in a partial state

Solution

Before auto-solving:

The game resets using undo history, not object destruction

All previous moves are undone via CommandInvoker

Command history is cleared

The solver then runs from a guaranteed valid base state

Benefits

AI can solve the puzzle from any situation

No need to regenerate towers or disks

Keeps object references intact

Avoids state corruption

🧠 Architecture Overview

The project follows separation of concerns:

Core Layers

GameManager

Orchestrates game flow (start, reset, auto-solve)

MoveService

Executes validated moves

Delegates undo/redo to CommandInvoker

CommandInvoker

Stores move history

Handles undo / redo

Provides move count

HanoiSolver

AI logic using recursion

UIManager

Handles buttons and move counter

Depends on interfaces, not concrete game systems

GameBootstrapper

Creates and injects all dependencies

🎯 Design Patterns Used

Command Pattern
For move execution, undo, redo, and reset

Dependency Injection
Services are created and wired in a single bootstrapper

Interface-Based Design
UI and solver depend on abstractions, not implementations

Single Responsibility Principle (SRP)
Each system has one clear purpose

🧪 Reset Strategy

Instead of destroying and recreating the level:

Reset is performed by undoing all executed commands

Command history is cleared afterward

This allows:

Faster reset

Cleaner state management

Easy replay and debugging

🚀 Future Improvements

Animated undo/redo transitions

Step-by-step AI solve visualization

Multiple solver strategies (heuristic / visual)

Save & load puzzle state

Difficulty scaling with disk count

📌 Summary

This project focuses not only on solving the Tower of Hanoi puzzle, but on building a clean, extensible system that demonstrates:

Algorithmic decision-making

Proper complexity analysis

Clean Unity architecture

Real-world undo/redo systems

AI integration with gameplay
