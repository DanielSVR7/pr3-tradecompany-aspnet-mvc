#!/bin/bash

set -e

DB_USER="${POSTGRES_USER}" 
DB_NAME="${POSTGRES_DB}"
BACKUP_FILE="/docker-entrypoint-initdb.d/backups/tradecompany.dump"

until pg_isready -U "$DB_USER"; do
  sleep 1
done

echo "Восстановление бекапа для пользователя: $DB_USER"
pg_restore -U "$DB_USER" -d "$DB_NAME" -Fc "$BACKUP_FILE" --no-owner --no-privileges

echo "Бекап успешно восстановлен в БД $DB_NAME пользователем $DB_USER!"