# Business Continuity and Disaster Recovery (BCDR)

## Recovery Objectives

| Tier | Service | RTO | RPO |
|------|---------|-----|-----|
| Critical | Authentication, core API | 1 hour | 15 min |
| High | Application servers | 4 hours | 1 hour |
| Medium | Analytics, reporting | 24 hours | 4 hours |

## Backup Strategy

- **Database:** Automated daily snapshots, 30-day retention; point-in-time recovery enabled
- **Configuration:** IaC stored in Git; environment configs in secrets manager
- **Artifacts:** Container images in registry with digest pinning

## Recovery Procedures

### Database Recovery
1. Identify latest clean snapshot
2. Restore to isolated environment and validate
3. Promote to production with traffic cutover

### Application Recovery
1. Re-deploy from pinned container image in IaC
2. Verify health checks pass
3. Gradually shift traffic (blue/green or canary)

## Testing Schedule

| Test Type | Frequency | Owner |
|-----------|-----------|-------|
| Backup restore drill | Monthly | Platform team |
| Full DR exercise | Quarterly | Engineering + Ops |
| Tabletop exercise | Semi-annual | All stakeholders |

Last tested: <!-- date -->
