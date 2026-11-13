# TLS Configuration Standards

## Minimum Requirements

- **TLS version:** TLS 1.2 minimum; TLS 1.3 preferred
- **TLS 1.0 and 1.1:** Disabled on all endpoints
- **SSL:** Disabled

## Cipher Suites (Preferred Order)

TLS 1.3:
```
TLS_AES_256_GCM_SHA384
TLS_AES_128_GCM_SHA256
TLS_CHACHA20_POLY1305_SHA256
```

TLS 1.2 (fallback):
```
ECDHE-ECDSA-AES256-GCM-SHA384
ECDHE-RSA-AES256-GCM-SHA384
ECDHE-ECDSA-AES128-GCM-SHA256
```

## Certificate Requirements

- Minimum RSA 2048-bit or EC P-256
- Valid, trusted CA (not self-signed in production)
- Certificate expiry monitoring with 30-day warning
- HSTS enabled: `Strict-Transport-Security: max-age=31536000; includeSubDomains`
- OCSP stapling enabled

## Verification

```bash
# Check TLS configuration
nmap --script ssl-enum-ciphers -p 443 your-domain.com
openssl s_client -connect your-domain.com:443 -tls1_2
```

## Tools

- [testssl.sh](https://testssl.sh/) for automated TLS auditing
- [SSL Labs](https://www.ssllabs.com/ssltest/) for web-facing endpoints
