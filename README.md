# NtCQRS
Решение является попыткой совместить шаблоны Repository и CQS (Command Query Separation).

#### Цель: 
более чистый код, удобство использования, поддержки и расширения.
Разделяем логику получения данных и логику изменения данных.
Инкапсулируем каждый запрос вместе с его параметрами и соединением с БД в отдельные классы.
Кастомизацию каждого запроса (фильтрация, пейджинг, сортировки) также можем задавать самостоятельно.
Для каждого запроса существует возможность реализовать как синхронный, так и асинхронный интерфейс.
Библиотека основана на Entity Framework 6.
Все сущности библиотеки реализуют некие интерфейсы и, соответвенно, могут быть легко внедрены при разработке с Dependency Injection.

Основной проект библиотеки - NtCQRS.Core - Содержит все основные интерфейсы и базовые классы

Пример работы с библиотекой - NtCQRS.Example.*

## Основные классы и интерфейсы

### interface IDbEntity
Единственным условием корректной работы вашего контекста данных с библиотекой NtCQRS - все ваши EF модели должны реализовать данный интерфейс.
Если подробнее - иметь поле Id.

### class RepositoryBase
Набор методов, реализующих основные операции с БД. 
Особенность: типизирован не сам класс, а каждый метод, для того чтобы 1 и тот же экземпляр репозитория можно было использовать
для запросов к разным наборам сущностей (DbSet-ам) из контекста.

### static class NtQueryableEx
Набор методов расширения, позволяющих применять "спецификации" к интерфейсу IQueryable, для кастомизации запроса.

### interface IDbCommand<in TParam, TResult>
Тип "команда" (Command) - любая операция изменяющая данные, может возвращать результат операции.
Для наиболее частых операций уже реализованы базовые команды.

#### public class AddOrUpdateCmd<TEntity>
Базовый класс для команд добавления/обновления некой сущности типа TEntity. для удобства
от него можно (и даже нужно) не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип

#### public class RemoveCmd<TEntity>
Базовый класс для команд удаления некой сущности типа TEntity. для удобства
от него можно (и даже нужно) не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип

### interface IDbQuery<TEntity, TSpecification>
Тип "запрос" (Query) - операция возвращающая данные, не имеет права ничего менять.
Интерфейс *IQuery* позволяет указать для каждого запроса спецификацию - некий набор параметров, оказывающий влияние на выполнение запроса.
Для уже готовых запросов (*GetListQuery*, *GetByIdQuery* ...) уже описаны требуемые ими спецификации.
Для создаваемых разработчиками кастомных запросов, вы можете определить набор данных и их использование самостоятельно.

#### public class GetByIdQuery<TEntity>
класс для запросов любых сущностей из БД по Id
от него можно (и даже нужно) не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип

#### public class GetListQuery<TEntity> : IDbQuery<List<TEntity>, QuerySpec<TEntity>> 
класс для запросов сущностей из БД списком
Spec - параметры запроса (фильтрация, пагинация, джоин)
от него можно (и даже нужно) не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип

#### public class GetOrderedListQuery<TEntity, TSortKey> : IDbQuery<List<TEntity>, OrderedQuerySpec<TEntity, TSortKey>>
класс для запросов сущностей из БД списком, 
Spec - паремтры запроса (фильтрация, пагинация, сортировка). 
от него можно (и даже нужно) не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип

### Спецификации запросов

#### public class QuerySpec<TEntity> 
Набор параметров для запроса *GetListQuery*.

#### public class OrderedQuerySpec<TEntity, TSortKey>
Набор параметров для запроса *GetListQuery*, требующий сортировки данных

Дальнейшее знакомство с библиотекой рекомендуется продолжать внутри проекта, видя реализацию каждого класса, связи и зависимости.
Основные концепции работы с библиотекой: выполнение существующих запросов и команд, реализация собственных спецификаций для существующих запросов, создание собственных "кастомных" запросов... - демонстрируются в проектах NtCQRS.Example.*

