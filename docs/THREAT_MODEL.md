# Threat Model

## Application Overview
<!-- Brief description of the application and its components -->

## Architecture Diagram
<!-- Embed or link to your data flow diagram (DFD) -->

## Trust Boundaries
| Boundary | Description |
|----------|-------------|
| Internet | Public-facing endpoints |
| DMZ | Load balancers and API gateways |
| Internal | Application servers and databases |

## Assets & Entry Points
| Asset | Description | Sensitivity |
|-------|-------------|-------------|
| User credentials | Authentication tokens and passwords | Critical |
| Customer PII | Personal identifiable information | High |
| API keys | Third-party service credentials | High |

## STRIDE Threat Analysis

### Spoofing
- Threat: Attacker impersonates legitimate user
- Mitigation: MFA, short-lived tokens, certificate pinning

### Tampering
- Threat: Attacker modifies data in transit or at rest
- Mitigation: TLS, digital signatures, integrity checks

### Repudiation
- Threat: User denies performing an action
- Mitigation: Immutable audit logs, cryptographic signing

### Information Disclosure
- Threat: Sensitive data exposed through errors or logging
- Mitigation: Structured error handling, log scrubbing, encryption at rest

### Denial of Service
- Threat: Application overwhelmed by requests
- Mitigation: Rate limiting, WAF, auto-scaling

### Elevation of Privilege
- Threat: Low-privilege user gains higher access
- Mitigation: RBAC, least-privilege, server-side authorisation checks

## Residual Risks
| Risk | Likelihood | Impact | Accepted? |
|------|-----------|--------|-----------|
| | | | |

## Review History
| Date | Reviewer | Version | Changes |
|------|----------|---------|---------|
| | | 1.0 | Initial |
