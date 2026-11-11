# Multi-Factor Authentication (MFA) Policy

## Scope

MFA is required for all access to:
- Cloud provider consoles (AWS, GCP, Azure)
- Version control systems (GitHub, GitLab)
- CI/CD platforms
- Production database access
- Administrative interfaces
- VPN access

## Accepted MFA Methods

| Method | Allowed | Notes |
|--------|---------|-------|
| Hardware security key (FIDO2/WebAuthn) | Yes (preferred) | Most secure |
| TOTP app (Authy, Google Authenticator) | Yes | Acceptable |
| Push notification (Duo, Okta Verify) | Yes | Acceptable |
| SMS OTP | No | Phishing-vulnerable |
| Email OTP | No | Account takeover risk |

## Implementation Requirements

- All admin accounts: hardware key required
- All developer accounts: TOTP minimum
- Service accounts: use short-lived tokens, no MFA bypass
- MFA enrollment within 24 hours of account creation
- MFA re-enrollment required if device is lost/replaced

## Exceptions

Exceptions require CISO approval and must be time-limited (max 30 days).
All exceptions are logged in the security exception register.
