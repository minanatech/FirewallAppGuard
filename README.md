# Firewall App Guard

A free, portable tool to block any Windows program from accessing the internet.

Firewall App Guard uses the Windows Firewall that is already built into your system. Point it at a program, click block, and that program can no longer reach the network. Click allow and it can again. Nothing is installed, no driver, no background service, and it only ever touches the rules it creates itself.

One executable, no installer.

---

## What it does

- Block any program from the internet by selecting its .exe
- Allow a blocked program to connect again
- See every program currently blocked by this tool
- Remove a program from the list and clean up its rules
- Works entirely through the built-in Windows Firewall

## Requirements

- Windows 7 SP1 or later (tested on Windows 10 and 11)
- .NET Framework 4.8 - already included in Windows 10 and 11
- Administrator rights, since changing firewall rules requires them

## Download

Get the latest build from the [Releases](https://github.com/minanatech/FirewallAppGuard/releases) page, or from [minanatech.com](https://minanatech.com).

Each release lists a SHA-256 checksum. To verify your download, run this in Command Prompt:

```
certutil -hashfile FirewallAppGuard.exe SHA256
```

The result should match the checksum published with that release.

## How it works

When you block a program, Firewall App Guard adds two rules to the Windows Firewall, one for outbound and one for inbound traffic, both scoped to that program's executable. Every rule it creates is named with a `FirewallAppGuard - ` prefix, so the tool can find its own rules later and never touches anything else in your firewall.

Allowing or removing a program deletes those rules again. Nothing is left behind that the tool did not put there.

## A note on antivirus warnings

Windows SmartScreen or your antivirus may warn about this program. This is what happens to any new executable from a developer without an established download history. It is a reputation check, not a detection of anything in the file.

You do not have to take our word for it. The source is here, the checksum is published, and the program is small enough to read in one sitting. Build it yourself if you would rather not run our binary.

## Building from source

Open `FirewallAppGuard.csproj` in Visual Studio and build in Release configuration. The project targets .NET Framework 4.8 and has no external dependencies.

## Licence

Released under the MIT Licence. See [LICENSE](LICENSE) for the full text.

The application icon is from the Squareplex icon set by Cornmanthe3rd. Please verify and credit its licence terms here before wider distribution.

---

Made by [minanatech.com](https://minanatech.com)
