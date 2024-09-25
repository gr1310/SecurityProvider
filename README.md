# Security Provider

## Overview

The Security Provider project aims on replicating security providers action, the code monitors specified files and on security event (any change in these files) notifies the user.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Design Patterns Demonstrated](#design-patterns-demonstrated)
- [Installation](#installation)
- [Usage](#usage)

## Features

- Real-time monitoring of file changes in specified directories.
- Support for multiple security providers, including antivirus and account security.
- User-friendly command-line interface for scanning and monitoring.
- Notifications for security events such as file creation and modification.

## Technologies Used

- C#
- .NET Framework
- FileSystemWatcher for monitoring file changes

## Design Patterns Demonstrated

- **Observer Pattern**: Facilitates communication between the `Controller` and various security providers, allowing subscribers to receive notifications about security events.
- **Factory Pattern**: The `Controller` class creates instances of security providers based on the selected environment (home or organization).
- **Command Pattern**: Encapsulates user commands as objects for processing.
- **Dependency Injection**: Promotes loose coupling and enhances testability using interfaces like `ICommunicator` and `ISecurityProvider`.

## Installation

To run this project, ensure you have the .NET SDK installed. Clone the repository and navigate to the project directory:

```bash
git clone https://github.com/yourusername/SecurityProvider.git
cd SecurityProvider
```

Build the project using:

```bash
dotnet build
```

## Usage
Run the application using the following command:

```bash
dotnet run
```

Follow the prompts to perform scans or exit the application. The program will notify you of any security events based on file changes in the monitored directories.

Example Commands:
Type scan to initiate a security scan.
Type quit to exit the application.
