# jason-money

My personal finance tracker.

This WIP program is currently not licensed.

## Development Setup

### Prerequisites

- .NET 7 SDK
- SQL Server Data Tools

### Database

NOTE: The database collation must include the "_UTF8" suffix e.g. `Latin1_General_100_CI_AS_SC_UTF8`.
By default, an English US OS defaults to `SQL_Latin1_General_CP1_CI_AS`, which does not include the UTF-8 option.
A "_UTF8" collation is required because it allows us to use VARCHAR while still supporting Unicode.
